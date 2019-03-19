using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfBoxes = 3;
            string[] boxList = new string[] { "ykc 82 01", "06f 12 25 6" };//new string[] { "ykc 82 01", "eo first qpx", "09z cat hamster", "06f 12 25 6", "az0 first qpx", "236 cat dog rabbit snake" };
            Console.Out.WriteLine(string.Join("\n", OrderedJunctionBoxes(numOfBoxes, boxList)));
            Console.ReadKey();
        }


        static List<string> OrderedJunctionBoxes(int numOfboxes, string[] boxList)
        {
            var data = boxList.ToList();
            data.Sort(new BoxComparer());
            return data;
        }

    }

    public class BoxComparer : IComparer<string>
    {
        public int Compare(string first, string second)
        {
            // Split first and second
            int firstIndex = first.IndexOf(' ');
            string firstCode = first.Substring(0, firstIndex);
            string firstValue = first.Substring(firstIndex);

            int secondIndex = second.IndexOf(' ');
            string secondCode = second.Substring(0, secondIndex);
            string secondValue = second.Substring(secondIndex);

            // Check for int
            // Remove the spaces in the value and try to parse int
            int firstInt = 0;
            bool isFirstInt = false;
            isFirstInt = int.TryParse(firstValue.Replace(" ", ""), out firstInt);

            int secondInt = 0;
            bool issecondInt = false;
            issecondInt = int.TryParse(secondValue.Replace(" ", ""), out secondInt);

            if (isFirstInt && issecondInt)
            {
                return 0;
            }

            if (isFirstInt && !issecondInt)
            {
                return 1;
            }

            if (!isFirstInt && issecondInt)
            {
                return -1;
            }


            // Check for older generation
            int result = string.Compare(firstValue, secondValue);

            // Incase of tie, return alphanumeric comparison
            if (result == 0)
            {
                return string.Compare(firstCode, secondCode);
            }
            return result;
        }
    }
}