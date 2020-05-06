using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorityElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MajorityElement(new int[] { 3, 3, 1 }));
            Console.WriteLine(MajorityElementBySorting(new int[] { 3, 3, 1 }));
            Console.ReadKey();
        }

        public static int MajorityElement(int[] nums)
        {
            Dictionary<int, int> numsCount = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (numsCount.ContainsKey(nums[i]))
                {
                    numsCount[nums[i]] = numsCount[nums[i]] + 1;
                }
                else
                {
                    numsCount.Add(nums[i], 1);
                }
            }

            foreach (var item in numsCount.Keys)
            {
                if (numsCount[item] > nums.Length / 2)
                {
                    return item;
                }
            }

            return -1;
        }

        // This can be used if it is ensured that a majority element always exists.
        public static int MajorityElementBySorting(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }
    }
}
