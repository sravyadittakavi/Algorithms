using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMPSearch
{
    class KMPSearch
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetIndexOfPattern("aaaabaabcba", "aabcb"));
            Console.ReadKey();
        }

        private static int GetIndexOfPattern(string text, string pattern)
        {
            int[] lsp = ComputeLSPTable(pattern);

            int j = 0;  // Number of chars matched in pattern
            for (int i = 0; i < text.Length; i++)
            {
                while (j > 0 && text.ElementAt(i) != pattern.ElementAt(j))
                {
                    // Fall back in the pattern
                    j = lsp[j - 1];  // Strictly decreasing
                }
                if (text.ElementAt(i) == pattern.ElementAt(j))
                {
                    // Next char matched, increment position
                    j++;
                    if (j == pattern.Length)
                        return i - (j - 1);
                }
            }
            return -1;  // Not found
        }

        private static int[] ComputeLSPTable(string pattern)
        {
            int length = pattern.Length;
            int[] lsp = new int[length];
            lsp[0] = 0;  // Base case
            for (int i = 1; i < length; i++)
            {
                // Start by assuming we're extending the previous LSP
                int j = lsp[i - 1];
                while (j > 0 && pattern.ElementAt(i) != pattern.ElementAt(j))
                {
                    j = lsp[j - 1];
                }
                if (pattern.ElementAt(i) == pattern.ElementAt(j))
                {
                    j++;
                }
                lsp[i] = j;
            }
            return lsp;
        }
    }
}
