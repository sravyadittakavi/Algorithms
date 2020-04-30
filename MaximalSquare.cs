using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] M = new char[6,5]{{'0', '1', '1', '0', '1'},
                    {'1', '1', '0', '1', '0'},
                    {'0', '1', '1', '1', '0'},
                    {'1', '1', '1', '1', '0'},
                    {'1', '1', '1', '1', '1'},
                    {'0', '0', '0', '0', '0'}};

            Console.WriteLine(MaximalSquare(M));
            Console.ReadKey();
        }

        public static int MaximalSquare(char[,] matrix)
        {
            int rows = matrix.Length, cols = rows > 0 ? matrix.GetLength(0) : 0;
            int[,] dp = new int[rows + 1, cols + 1];
            int maxsqlen = 0;
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    if (matrix[i - 1,j - 1] == '1')
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i, j - 1], dp[i - 1, j]), dp[i - 1, j - 1]) + 1;
                        maxsqlen = Math.Max(maxsqlen, dp[i, j]);
                    }
                }
            }
            return maxsqlen * maxsqlen;
        }
    }
}
