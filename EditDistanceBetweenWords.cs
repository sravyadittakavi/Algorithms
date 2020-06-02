using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditDistanceBetweenWords
{
    class EditDistanceBetweenWords
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinDistance("horse", "ros"));
            Console.ReadLine();
        }

        // Use DP. Form a DP matrix. Say the lengths of strings are m & n respectively.
        // If last chars are equal, compute distance till last but one char, dp[m-1][n-1]
        // Else using DP matrix, one of the 3 given operations should be perfomed
        //      If we should delete the char in first string, then result will be (1+dp[m-1][n])
        //      If we should replace the char, then result will be (1+dp[m-1][n-1])
        //      If we should insert the char, then result will be (1+dp[m][n-1])
        // Take min of these 3 cases.
        public static int MinDistance(string word1, string word2)
        {
            int m = word1.Length, n = word2.Length;
            int[,] dp = new int[m + 1, n + 1];

            for(int i = 0; i <= m; i++)
            {
                for(int j = 0; j <= n; j++)
                {
                    if (i == 0)
                        dp[i, j] = j;
                    else if (j == 0)
                        dp[i, j] = i;
                    else
                    {
                        if (word1[i - 1] == word2[j - 1])
                            dp[i, j] = dp[i - 1, j - 1];
                        else
                            dp[i, j] = 1 + Math.Min(dp[i, j - 1], Math.Min(dp[i - 1, j - 1], dp[i - 1, j]));
                    }
                }
            }

            return dp[m, n];            
        }
    }
}
