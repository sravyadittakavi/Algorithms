using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestCommonSubsequence("abcde", "acef"));
            Console.ReadKey();
        }

        public static int LongestCommonSubsequence(string text1, string text2)
        {
            char[] X = text1.ToCharArray();
            char[] Y = text2.ToCharArray();
            int m = X.Length;
            int n = Y.Length;
            int[,] L = new int[m + 1, n + 1];

            /* Following steps build L[m+1][n+1]  
            in bottom up fashion. Note 
            that L[i][j] contains length of  
            LCS of X[0..i-1] and Y[0..j-1] */
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        L[i, j] = 0;
                    else if (X[i - 1] == Y[j - 1])
                        L[i, j] = L[i - 1, j - 1] + 1;
                    else
                        L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
                }
            }
            return L[m, n];
        }
    }
}
