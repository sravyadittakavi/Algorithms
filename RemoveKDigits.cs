using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveKDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RemoveKDigits("10", 2));
            Console.ReadKey();
        }

        public static string RemoveKDigits(string num, int k)
        {
            // We should iterate from the left to right, when removing the digits. 
            // The more a digit to the left-hand side, the more weight it carries.
            Stack<char> digits = new Stack<char>();

            foreach(char x in num.ToCharArray())
            {
                while(digits.Count != 0 && k!= 0 && digits.Peek() > x)
                {
                    digits.Pop();
                    k--;
                }
                digits.Push(x);
            }

            for(int i = 0; i < k; i++)
            {
                digits.Pop();
            }
            
            StringBuilder returnString = new StringBuilder();
            
            while(digits.Count > 0)
            {
                char x = digits.Pop();              
                returnString.Append(x);
            }

            char[] retArr = returnString.ToString().ToCharArray();
            Array.Reverse(retArr);
            string output = new string(retArr).TrimStart(new char[] { '0' });
            return output==""?"0":output;
        }
    }
}
