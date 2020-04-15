using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringShift
{
    class StringShift
    {
        static void Main(string[] args)
        {
            int[][] shift = new int[4][];
            for (int i = 0; i < 4; i++)
            {
                shift[i] = new int[2];
                if (i == 0)
                {
                    shift[i][0] = 1;
                    shift[i][1] = 1;
                }
                if (i == 1)
                {
                    shift[i][0] = 1;
                    shift[i][1] = 1;
                }
                if (i == 2)
                {
                    shift[i][0] = 0;
                    shift[i][1] = 2;
                }
                if (i == 3)
                {
                    shift[i][0] = 1;
                    shift[i][1] = 3;
                }
            }

            string s = "abcdefg";
            Console.WriteLine(StringShift(s, shift));
            Console.ReadKey();
        }

        public static string StringShift(string s, int[][] shift)
        {
            int[,] finalShift = new int[1,2];
            finalShift = GetRemainderShift(shift);

            int finalShiftAmount = finalShift[0, 1];

            StringBuilder sb = new StringBuilder(s);

            if(finalShift[0,0] == 0)
            {               
                for (int i = 0; i < finalShiftAmount; i++)
                {
                    char first = sb[0];
                    for (int j = 1; j < s.Length; j++)
                    {
                        sb[j - 1] = sb[j];
                    }
                    sb[s.Length-1] = first;
                }
            }
            else if(finalShift[0,0] == 1)
            {
                for (int i = 0; i < finalShiftAmount; i++)
                {
                    char last = sb[s.Length - 1];
                    for (int j = s.Length-1; j > 0 ; j--)
                    {
                        sb[j] = sb[j - 1];
                    }
                    sb[0] = last;
                }
            }
            return sb.ToString();
        }

        public static int[,] GetRemainderShift(int[][] shift)
        {
            int leftShiftAmount = 0;
            int rightShiftAmount = 0;
            int[,] finalShift = new int[1,2];
            for(int i = 0; i < shift.Length; i++)
            {
                if(shift[i][0] == 0)
                {
                    leftShiftAmount += shift[i][1];
                }
                if (shift[i][0] == 1)
                {
                    rightShiftAmount += shift[i][1];
                }              
            }

            if (leftShiftAmount == rightShiftAmount)
                return finalShift;
            if(leftShiftAmount > rightShiftAmount)
            {
                finalShift = new int[,] { { 0, leftShiftAmount - rightShiftAmount } };
            }
            else
            {
                finalShift = new int[,] { { 1, rightShiftAmount - leftShiftAmount } };
            }
            return finalShift;
        }
    }
}
