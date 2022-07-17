using System;
using System.Collections.Generic;
using System.Linq;

namespace AEChaosModManaged
{
    internal class VotingManager<T> where T : IEquatable<T>
    {
        internal Dictionary<string, T> Voters { get; private set; }
        internal List<(T item, int votes)> Options { get; private set; }

        internal VotingManager(int maxOptionCount)
        {
            Voters = new Dictionary<string, T>();
            Options = new List<(T item, int votes)>(maxOptionCount);
        }

        internal void HandleVote(string username, string message)
        {
            var msg = message.Split(' ')[0].TrimStart('#');
            if (int.TryParse(msg, out var vote) && vote >= 1 && vote <= Options.Count)
            {
                var option = Options[vote - 1];

                if (Voters.ContainsKey(username))
                {
                    var userVotedFor = Voters[username];
                    if (userVotedFor.Equals(option.item))
                        return;

                    for (int i = 0; i < Options.Count; i++)
                    {
                        if (Options[i].item.Equals(userVotedFor))
                        {
                            Options[i] = (userVotedFor, Options[i].votes - 1);
                            break;
                        }
                    }

                    Voters.Remove(username);
                }

                Voters.Add(username, option.item);
                Options[vote - 1] = (option.item, option.votes + 1);
            }
        }

        internal T GetResult()
        {
            var maxVote = Options.Max(x => x.votes);
            var maxVoted = Options.Where(x => x.votes == maxVote).Select(x => x.item).ToList();

            if (maxVoted.Count == 1)
                return maxVoted[0];
            else
                return maxVoted[new Random().Next(0, maxVoted.Count)];
        }

        internal void Reset(IEnumerable<T> newOptions)
        {
            Voters.Clear();
            Options.Clear();

            foreach (var newOption in newOptions)
                Options.Add((newOption, 0));
        }

        internal T GetResultAndReset(IEnumerable<T> newOptions)
        {
            T result = GetResult();
            Reset(newOptions);

            return result;
        }
    }
}
