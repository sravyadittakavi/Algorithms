using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 1, 2, 3 };
            Console.WriteLine(SubarraySum(nums, 3));
            Console.WriteLine(SubarraySumWithoutDictionary(nums, 3));
            Console.ReadKey();
        }

        public static int SubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> sumCounts = new Dictionary<int, int>();

            int sum = 0;

            // Add first entry of 0 to dict
            sumCounts.Add(0, 1);
            int counter = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                // If (sum till index i - sum till index j) = k,
                // then sum from index i to j will be k
                // This is used below to store the counts 
                // in dictionary
                if (sumCounts.ContainsKey(sum - k))
                {
                    int val = sumCounts[sum - k];
                    counter += val;                   
                    sumCounts[sum - k] = val+1;
                }
              
                sumCounts.Add(sum, 1);
                
            }
            return counter;
        }

        public static int SubarraySumWithoutDictionary(int[] nums, int k)
        {
            int sum = 0, counter = 0;

            for(int start = 0; start < nums.Length; start++)
            {
                sum = 0;
                for(int end = start; end < nums.Length; end++)
                {
                    sum += nums[end];

                    if (sum == k)
                        counter++;
                }
            }

            return counter;
        }
    }
}
