using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AEChaosModManaged
{
    internal class IRCClient
    {
        private static readonly Regex messageRegex = new Regex(@".*?(?<username>.+)!(?:\1).*PRIVMSG\s*#.*\s*:\s*(?<message>.+)", RegexOptions.Compiled);
        private static readonly string server = "irc.chat.twitch.tv";
        private static readonly int port = 6667;

        private readonly string oauth;
        private readonly string nickName;
        private readonly string channelName;

        internal event EventHandler<MessageReceivedEventArgs> MessageReceived;

        private Queue<string> commandQueue;
        private List<(string username, string message)> recievedMsgs;
        private object fileLock = new object();

        private CancellationToken cancellationToken;
        private bool internalStop = false;
        private TcpClient tcpClient;
        private Task taskIngoing, taskOutgoing;

        private bool isConnected = false;
        private bool isJoined = false;

        internal IRCClient(string channelName, string nickName = null, string oauth = null)
        {
            this.channelName = channelName;
            this.nickName = nickName ?? "justinfan" + new Random().Next(10000, 99999);
            this.oauth = oauth ?? this.nickName;
        }

        private void StartIRC()
        {
            try
            {
                Log("Starting");

                commandQueue = new Queue<string>();
                recievedMsgs = new List<(string username, string message)>();

                tcpClient = new TcpClient();
                tcpClient.Connect(server, port);
                if (!tcpClient.Connected)
                {
                    ChaosMod.Instance.ErrorInfo = "Failed to connect to Twitch!";
                    return;
                }
                else
                {
                    Log("Connected to Twitch!");
                    ChaosMod.Instance.ErrorInfo = null;
                }

                var networkStream = tcpClient.GetStream();
                var input = new StreamReader(networkStream);
                var output = new StreamWriter(networkStream);

                taskOutgoing = new Task(() => IRCOutputProcedure(output));
                taskOutgoing.Start();

                taskIngoing = new Task(() => IRCInputProcedure(input, networkStream));
                taskIngoing.Start();

                //Send PASS & NICK.
                Log("OUT: PASS " + oauth);
                output.WriteLine("PASS " + oauth);
                output.Flush();
                Log("OUT: NICK " + nickName.ToLower());
                output.WriteLine("NICK " + nickName.ToLower());
                output.Flush();
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }

        private void IRCInputProcedure(TextReader input, NetworkStream networkStream)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    if (internalStop)
                        break;

                    while (networkStream.DataAvailable)
                    {
                        string buffer = input.ReadLine();

                        Log("IN:  " + buffer);

                        if (buffer.Contains("PRIVMSG #")) //was message?
                        {
                            var match = messageRegex.Match(buffer);
                            if (match.Success)
                            {
                                lock (recievedMsgs)
                                {
                                    recievedMsgs.Add((match.Groups["username"].Value, match.Groups["message"].Value));
                                }
                            }
                        }
                        else if (buffer.StartsWith("PING ")) //Send pong reply to any ping messages
                        {
                            SendCommand(buffer.Replace("PING", "PONG"));
                        }
                        else if (buffer.Split(' ')[1] == "001") //After server sends 001 command, we can join a channel
                        {
                            isConnected = true;
                            SendCommand("JOIN #" + channelName);
                        }
                        else if (buffer.Contains("JOIN #" + channelName))
                        {
                            isJoined = true;
                        }
                        else if (buffer.Contains("Login authentication failed") || buffer.Contains("RECONNECT"))
                        {
                            Reconnect();
                        }
                    }

                    if (stopWatch.ElapsedMilliseconds > 5000)
                    {
                        stopWatch.Restart();
                        if (isConnected)
                        {
                            if (!isJoined)
                                SendCommand("JOIN #" + channelName);
                        }
                        else
                        {
                            Reconnect();
                        }
                    }

                    try
                    {
                        Task.Delay(25).Wait(cancellationToken);
                    }
                    catch (OperationCanceledException)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }

        private void IRCOutputProcedure(TextWriter output)
        {
            try
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                while (!cancellationToken.IsCancellationRequested)
                {
                    if (internalStop)
                        break;

                    lock (commandQueue)
                    {
                        var isJoinMessage = commandQueue.Count > 0 ? commandQueue.Peek().Contains("JOIN") : false;
                        if (commandQueue.Count > 0 && (isJoined || isJoinMessage))
                        {
                            if (stopWatch.ElapsedMilliseconds > 1500 || isJoinMessage) // max 20 messages per 30 seconds
                            {
                                var outputMsg = commandQueue.Dequeue();

                                Log("OUT: " + outputMsg);

                                output.WriteLine(outputMsg);
                                output.Flush();

                                stopWatch.Restart();
                            }
                        }
                    }

                    try
                    {
                        Task.Delay(150).Wait(cancellationToken);
                    }
                    catch (OperationCanceledException)
                    {

                    }
                }

                if (isJoined)
                {
                    Log("OUT: PART " + channelName.ToLower());
                    output.WriteLine("PART " + channelName.ToLower());
                    output.Flush();
                    isJoined = false;
                }
            }
            catch (Exception ex)
            {
                if (ex is OperationCanceledException)
                    return;

                Log(ex.ToString());
            }
        }

        private void Reconnect()
        {
            Task.Run(() =>
            {
                try
                {
                    Wait();
                    Dispose();
                    StartIRC();
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                }
            });
        }

        private void Log(string msg)
        {
            lock (fileLock)
            {
                File.AppendAllText("irclog.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff  ") + msg + Environment.NewLine);
            }
        }

        internal void SendCommand(string cmd)
        {
            lock (commandQueue)
            {
                commandQueue.Enqueue(cmd);
            }
        }

        internal void SendMsg(string msg)
        {
            lock (commandQueue)
            {
                commandQueue.Enqueue("PRIVMSG #" + channelName + " :" + msg);
            }
        }

        internal void Start(CancellationToken cancellationToken)
        {
            this.cancellationToken = cancellationToken;
            StartIRC();
        }

        internal void Update()
        {
            lock (recievedMsgs)
            {
                if (recievedMsgs.Count > 0)
                {
                    foreach (var receivedMsg in recievedMsgs)
                        MessageReceived?.Invoke(this, new MessageReceivedEventArgs(receivedMsg.username, receivedMsg.message));

                    recievedMsgs.Clear();
                }
            }
        }

        internal void Wait()
        {
            if (!cancellationToken.IsCancellationRequested)
                internalStop = true;

            if (taskIngoing != null && !taskIngoing.IsCompleted)
                taskIngoing.Wait();

            if (taskOutgoing != null && !taskOutgoing.IsCompleted)
                taskOutgoing.Wait();

            internalStop = false;
        }

        public void Dispose()
        {
            tcpClient?.Dispose();
            tcpClient = null;

            isJoined = false;
            isConnected = false;
            Log("Closed" + Environment.NewLine);

            taskIngoing?.Dispose();
            taskIngoing = null;

            taskOutgoing?.Dispose();
            taskOutgoing = null;
        }

        internal class MessageReceivedEventArgs : EventArgs
        {
            internal string Username { get; private set; }
            internal string Message { get; private set; }
            internal MessageReceivedEventArgs(string username, string message)
            {
                Username = username;
                Message = message;
            }
        }
    }
}
