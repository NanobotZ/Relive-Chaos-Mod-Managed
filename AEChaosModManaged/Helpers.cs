using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEChaosModManaged
{
    internal static class Helpers
    {
        internal static IEnumerable<string> SplitEveryNCharactersWithDelimeter(this string input, int n)
        {
            List<string> chunks = new List<string>();

            while (input.Length > 0)
            {
                if (input.Length <= n)
                {
                    chunks.Add(input);
                    break;
                }

                string chunk = input.Substring(0, n);

                if (char.IsWhiteSpace(input[n]))
                {
                    chunks.Add(chunk);
                    input = input.Substring(chunk.Length + 1);
                }
                else
                {
                    int splitIndex = chunk.LastIndexOf(' ');
                    if (splitIndex != -1)
                        chunk = chunk.Substring(0, splitIndex);
                    input = input.Substring(chunk.Length + (splitIndex == -1 ? 0 : 1));
                    chunks.Add(chunk);
                }
            }

            return chunks;
        }
    }
}
