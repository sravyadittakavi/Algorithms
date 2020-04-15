using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOfArrayExceptSelf
{
    class ProductOfArrayExceptSelf
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 4 };

            int[] ans = ProductExceptSelf(nums);
            for (int i = 0; i < ans.Length; i++) 
            {
                Console.Write(ans[i]+" ");
            }
            Console.ReadKey();
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            int length = nums.Length;
            int[] left = new int[length];
            int[] right = new int[length];
            int[] ans = new int[length];

            // Get left product of each number
            left[0] = 1;
            for(int i = 1; i < length; i++)
            {
                left[i] = left[i - 1] * nums[i - 1];
            }

            // Get right product of each number
            right[length - 1] = 1;
            for(int i = length - 2; i >= 0; i--)
            {
                right[i] = right[i + 1] * nums[i + 1];
            }

            for(int i=0; i < nums.Length; i++)
            {
                ans[i] = left[i] * right[i];
            }

            return ans;
        }
    }
}
