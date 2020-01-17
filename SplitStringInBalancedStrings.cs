using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitStringInBalancedStrings
{
    class SplitStringInBalancedStrings
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BalancedStringSplit("RLLLLRRRLR"));
            Console.ReadLine();
        }

        private static int BalancedStringSplit(string s)
        {
            if(s==null || s.Length == 0 || s.Length%2 != 0)
            {
                return 0;
            }

            int lcount = 0, rcount = 0, result = 0;         
            for(int i = 0; i < s.Length; i = i + 2)
            {
                if (s[i] == 'L') lcount++;
                if (s[i+1] == 'L') lcount++;
                if (s[i] == 'R') rcount++;
                if (s[i + 1] == 'R') rcount++;

                if(lcount == rcount)
                {
                    result++;
                    lcount = 0;
                    rcount = 0;
                }
            }
            return result;
        }
    }
}
