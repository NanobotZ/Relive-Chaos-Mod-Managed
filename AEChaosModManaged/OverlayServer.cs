using Fleck;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AEChaosModManaged
{
    internal class OverlayServer
    {
        private VotingManager<BaseEffect> votingManager;
        private CancellationToken cancellationToken;
        private Task taskBroadcaster;
        private List<IWebSocketConnection> webSocketConnections;
        private object broadcastVotesObj = new object();
        private bool broadcastVotes;
        private bool internalStop;

        private WebSocketServer webSocketServer;

        public OverlayServer(VotingManager<BaseEffect> votingManager)
        {
            this.votingManager = votingManager;
            broadcastVotes = false;
            webSocketConnections = new List<IWebSocketConnection>();
        }

        private void WebSocketBroadcasterJob()
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (internalStop)
                    break;

                lock (broadcastVotesObj)
                {
                    if (broadcastVotes)
                    {
                        broadcastVotes = false;

                        lock (webSocketConnections)
                        {
                            if (webSocketConnections.Count > 0)
                            {
                                var message = ConstructVotesJson();

                                foreach (var webSocketConnection in webSocketConnections)
                                {
                                    webSocketConnection.Send(message);
                                }
                            }
                        }
                    }
                }

                try
                {
                    Task.Delay(50).Wait(cancellationToken);
                }
                catch (OperationCanceledException)
                {

                }
            }
        }

        internal string ConstructVotesJson()
        {
            var sb = new StringBuilder();

            sb.Append("{");

            sb.Append("\"totalVotes\":");
            sb.Append(votingManager.Voters.Count);

            sb.Append(",\"options\":[");

            int index = 0;
            foreach (var option in votingManager.Options)
            {
                sb.Append("{\"index\":");
                sb.Append(++index);
                sb.Append(",\"name\":\"");
                sb.Append(option.item.Name);
                sb.Append("\",\"votes\":");
                sb.Append(option.votes);
                sb.Append("}");
                if (index != votingManager.Options.Count)
                    sb.Append(",");
            }

            sb.Append("]}");

            return sb.ToString();
        }

        internal void UpdateVotes()
        {
            lock (broadcastVotesObj)
            {
                broadcastVotes = true;
            }
        }

        internal void Start(CancellationToken cancellationToken)
        {
            this.cancellationToken = cancellationToken;

            webSocketServer = new WebSocketServer("ws://0.0.0.0:42069");
            webSocketServer.Start(connection =>
            {
                connection.OnOpen += () => {
                    lock (webSocketConnections)
                        webSocketConnections.Add(connection);

                    UpdateVotes();
                };
                connection.OnClose += () => {
                    lock (webSocketConnections)
                        webSocketConnections.Remove(connection);
                };
            });

            taskBroadcaster = new Task(() => WebSocketBroadcasterJob());
            taskBroadcaster.Start();
        }

        internal void Wait()
        {
            if (!cancellationToken.IsCancellationRequested)
                internalStop = true;

            if (taskBroadcaster != null && !taskBroadcaster.IsCompleted)
                taskBroadcaster.Wait();

            internalStop = false;
        }

        public void Dispose()
        {
            lock (webSocketConnections)
            {
                foreach (var webSocketClient in webSocketConnections)
                {
                    webSocketClient.Close();
                }
                webSocketConnections.Clear();
            }

            webSocketServer?.Dispose();
            webSocketServer = null;

            taskBroadcaster?.Dispose();
            taskBroadcaster = null;
        }
    }
}
