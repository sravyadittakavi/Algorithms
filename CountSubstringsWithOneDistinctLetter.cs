using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSubstringsWithOneDistinctLetter
{
    class CountSubstringsWithOneDistinctLetter
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountLetters("aaaaaaaaaa"));
            Console.ReadLine();
        }

        public static int CountLetters(string S)
        {
            if(S==null || S.Length == 0)
            {
                return 0;
            }
            if(S.Length == 1)
            {
                return 1;
            }
            int result = 0;
            char prevChar = S[0];
            int repeatCount = 0;
            foreach(var a in S)
            {
                char nextChar = a;
                if(nextChar == prevChar)
                {
                    repeatCount++;
                }
                else
                {
                    repeatCount = 1;
                }
                result += repeatCount;
                prevChar = nextChar;
            }
            return result;
        }
    }
}
