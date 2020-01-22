using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLowerCase
{
    class ToLowerCase
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConvertToLowerCase("hello"));
            Console.ReadLine();
        }

        private static string ConvertToLowerCase(string str)
        {
            StringBuilder result = new StringBuilder();
            foreach(var a in str)
            {
                // The input letter will be uppercase in this case
                if (Convert.ToInt32(a) >= 65 && Convert.ToInt32(a) <= 91)
                {
                    int diff = a - 'A';
                   
                    // Ascii value of lowercase a is 97.
                    int lowerChar = 'a' + diff;
                    result.Append(Convert.ToChar(lowerChar));                  
                }
                else
                {
                    result.Append(a);
                }
            }
            return result.ToString();
        }
    }
}
