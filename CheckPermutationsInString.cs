using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPermutationsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CheckInclusion("ab", "eidbaooo"));
            Console.ReadLine();
        }

        public static bool CheckInclusion(string s1, string s2)
        {
            int s1Length = s1.Length, s2Length = s2.Length;
            if (s1Length > s2Length) return false;

            int[] s1Count = new int[26];
            int[] s2Count = new int[26];

            // build reference array using string s1
            foreach (char ch in s1.ToCharArray())
            {
                s1Count[(int)(ch - 'a')]++;
            }

            // sliding window on the string s2
            for (int i = 0; i < s2Length; ++i)
            {
                // add one more letter 
                // on the right side of the window
                s2Count[(int)(s2[i] - 'a')]++;
                // remove one letter 
                // from the left side of the window
                if (i >= s1Length)
                {
                    s2Count[(int)(s2[i - s1Length] - 'a')]--;
                }
                // compare array in the sliding window
                // with the reference array
                if (string.Join(",", s1Count) == string.Join(",", s2Count))
                {
                    //They are the same
                    return true;
                }
            }
            return false;
        }
    }
}
