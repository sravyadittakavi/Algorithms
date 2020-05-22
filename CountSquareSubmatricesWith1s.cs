using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSquareSubmatricesWith1s
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][];
          
            matrix[0] = new int[4] { 0, 1, 1, 1 };
            matrix[1] = new int[4] { 1, 1, 1, 1 };
            matrix[2] = new int[4] { 0, 1, 1, 1 };

            Console.WriteLine(CountSquares(matrix));
            Console.ReadLine();
        }

        public static int CountSquares(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            int topLeft = 0;
            int result = 0;

            int[] temp = new int[n];

            for (int i = 0; i < m; i++)
            {
                topLeft = 0;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 1)
                    {

                        int top = i == 0 ? 0 : temp[j];
                        int left = j == 0 ? 0 : temp[j - 1];

                        temp[j] = 1 + Math.Min(topLeft, Math.Min(top, left));
                        result += temp[j];

                        topLeft = top;
                    }
                    else
                    {
                        temp[j] = 0;
                    }
                }
            }

            return result;
        }
    }
}
