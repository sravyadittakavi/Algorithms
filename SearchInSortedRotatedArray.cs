using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSortedRotatedArray
{
    class SearchInSortedRotatedArray
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 4, 5, 6, 7, 0, 1, 2 };
            int n = arr1.Length;
            int key = 0;
            Console.Write("Index of the element is : "
                        + PivotedBinarySearch(arr1, n, key));
            Console.ReadKey();
        }

        public static int FindPivot(int[] nums, int low, int high)
        {
            if (high < low)
                return -1;
            if (high == low)
                return low;

            int mid = (low + high) / 2;
            if (mid < high && nums[mid] > nums[mid + 1])
                return mid;
            if (mid > low && nums[mid - 1] > nums[mid])
                return mid - 1;
            if (nums[low] >= nums[mid])
                return FindPivot(nums, low, mid - 1);
            return FindPivot(nums, mid + 1, high);
        }

        public static int BinarySearch(int[] nums, int low, int high, int target)
        {
            if (high < low)
                return -1;

            int mid = (low + high) / 2;

            if (nums[mid] == target)
                return mid;
            if (target > nums[mid])
                return BinarySearch(nums, mid + 1, high, target);
            return BinarySearch(nums, low, mid - 1, target);
        }

        public static int PivotedBinarySearch(int[] nums, int n, int target)
        {
            int pivot = FindPivot(nums, 0, n - 1);

            if (pivot == -1)
                return BinarySearch(nums, 0, n - 1, target);

            if (nums[pivot] == target)
                return pivot;

            if (nums[0] <= target)
                return BinarySearch(nums, 0, pivot - 1, target);

            return BinarySearch(nums, pivot + 1, n - 1, target);
        }
    }
}
