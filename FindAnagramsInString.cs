using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = FindAnagrams("cbaebabacd", "abc");
            Console.WriteLine("["+String.Join(",", l)+"]");
            Console.ReadLine();
        }

        public static IList<int> FindAnagrams(string s, string p)
        {
            int ns = s.Length, np = p.Length;
            if (ns < np) return new List<int>();

            int[] pCount = new int[26];
            int[] sCount = new int[26];
            // build reference array using string p
            foreach (char ch in p.ToCharArray())
            {
                pCount[(int)(ch - 'a')]++;
            }

            List<int> output = new List<int>();
            // sliding window on the string s
            for (int i = 0; i < ns; ++i)
            {
                // add one more letter 
                // on the right side of the window
                sCount[(int)(s[i] - 'a')]++;
                // remove one letter 
                // from the left side of the window
                if (i >= np)
                {
                    sCount[(int)(s[i - np] - 'a')]--;
                }
                // compare array in the sliding window
                // with the reference array
                if (string.Join(",", pCount) == string.Join(",", sCount))
                {
                    //They are the same
                    output.Add(i - np + 1);
                }
            }
            return output;
        }
    }
}
