using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleElementInSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SingleNonDuplicate(new int[] { 1, 1, 2, 2, 3, 4, 4, 5, 5, 7, 7 }));
            Console.ReadKey();
        }

        public static int SingleNonDuplicate(int[] nums)
        {
            // In the given array, it is known that number at every even index = number at next index.
            // Wherever there is this violation, the number is the result.
            int low = 0, high = nums.Length - 1;
            while(low < high)
            {
                int mid = low + (high - low) / 2;
                // To check our logic, mid should always be even. Hence make it even if it is not, by
                // considering the previous index.
                if (mid % 2 == 1)
                    mid = mid - 1;
                if (nums[mid] == nums[mid + 1])
                    low = mid + 2;
                else
                    high = mid;
            }

            return nums[low];
        }
    }
}
