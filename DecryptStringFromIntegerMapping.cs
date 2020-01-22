using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecryptStringFromIntegerMapping
{
    class DecryptStringFromIntegerMapping
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DecryptString("12345678910#11#12#13#14#15#16#17#18#19#20#21#22#23#24#25#26#"));
            Console.ReadLine();
        }

        private static string DecryptString(string s)
        {
            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                {"1","a" },
                {"2","b" },
                {"3","c" },
                {"4","d" },
                {"5","e" },
                {"6","f" },
                {"7","g" },
                {"8","h" },
                {"9","i" },
                {"10#","j" },
                {"11#","k" },
                {"12#","l" },
                {"13#","m" },
                {"14#","n" },
                {"15#","o" },
                {"16#","p" },
                {"17#","q" },
                {"18#","r" },
                {"19#","s" },
                {"20#","t" },
                {"21#","u" },
                {"22#","v" },
                {"23#","w" },
                {"24#","x" },
                {"25#","y" },
                {"26#","z" }
            };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if(i+2 < s.Length && s[i+2]  == '#')
                {
                    string key = new string(new char[] { s[i], s[i + 1], s[i + 2] });
                    sb.Append(data[key]);
                    i = i + 2;
                }
                else
                {
                    sb.Append(data[s[i].ToString()]);
                }
            }
            return sb.ToString();
        }
    }
}
