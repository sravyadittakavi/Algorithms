using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateTimeToTypeAWord
{
    class CalculateTimeToTypeAWord
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CalculateTime("pqrstuvwxyzabcdefghijklmno", "leetcode"));
            Console.ReadLine();
        }

        private static int CalculateTime(string keyboard, string word)
        {
            int prevIndex = 0, result = 0, currIndex = 0;
            foreach(var a in word)
            {
                currIndex = keyboard.IndexOf(a);
                result += Math.Abs(prevIndex - currIndex);
                prevIndex = currIndex;
            }
            return result;
        }
    }
}
