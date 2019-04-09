using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberCombinations
{
    class Program
    {
        private static Dictionary<char, string> phoneStrings = new Dictionary<char, string>()
        {
            {'1',""},
            {'2',"abc" },
            {'3',"def" },
            {'4',"ghi" },
            {'5',"jkl" },
            {'6',"mno" },
            {'7',"pqrs"},
            {'8',"tuv" },
            {'9',"wxyz"}
        };

        static void Main(string[] args)
        {
            string input = "236";
            List<string> output = new List<string>();

            char first = input.ToCharArray()[0];
            string firstValue = phoneStrings[first];
            int counter = 0;
            foreach(char a in firstValue.ToCharArray())
            {
               output.Add(a.ToString());
               counter++;
            }
            counter = 0;
            foreach (char a in input.ToCharArray())
            {
                if (counter != 0)
                {
                    output = GetAllCombinations(output, phoneStrings[a]);
                }
                counter++;
            }

            Console.WriteLine("String is " + string.Join(",", output));
            Console.ReadKey();
        }

        private static List<string> GetAllCombinations(List<string> res, string input)
        {
            List<string> output = new List<string>();
            for(int i=0;i<input.Length;i++)
            {
                for(int j = 0; j < res.Count; j++)
                {
                    output.Add(res[j] + input.ToCharArray()[i]);
                }
                
            }
            return output;
        }
    }
}
