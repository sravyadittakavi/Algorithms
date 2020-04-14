using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContiguousArray
{
    class ContiguousArray
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 0, 1, 1, 0, 1 };
            Console.WriteLine(FindMaxLength(nums));
            Console.ReadKey();
        }

        public static int FindMaxLength(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            
            int maxlen = 0, count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                count = count + (nums[i] == 1 ? 1 : -1);
                if(count == 0)
                {
                    maxlen = Math.Max(maxlen, i + 1);
                }
                if (map.ContainsKey(count))
                {
                    maxlen = Math.Max(maxlen, i - map[count]);
                }
                else
                {
                    map.Add(count, i);
                }
            }
            return maxlen;
        }
    }
}
