using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayRotation
{
    class ArrayRotation
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            Console.WriteLine("--LeftRotateUsingReversalAlgo--");
            PrintArray(arr);
            LeftRotateUsingReversalAlgo(arr, 2);
            PrintArray(arr);

            arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine("--LeftRotateArrayWithTempArray--");
            PrintArray(arr);
            LeftRotateArrayWithTempArray(arr, 2);
            PrintArray(arr);

            arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine("--LeftRotateArray--");
            PrintArray(arr);
            LeftRotateArrayByOneDTimes(arr, 2);
            PrintArray(arr);

            Console.WriteLine("Index of 4: " +PivotedBinarySearch(arr, 4, 7));

            Console.Read();
        }

        public static void PrintArray(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        // Time complexity O(n), space complexity O(d)
        public static void LeftRotateArrayWithTempArray(int[] arr, int d)
        {
            int[] temp = new int[d];
            for(int i = 0; i < d; i++)
            {
                temp[i] = arr[i];
            }
            for(int i = 0; i < arr.Length-d; i++)
            {
                arr[i] = arr[i + d];
            }
            int tempIndex = 0;
            for(int i = arr.Length - d; i < arr.Length; i++)
            {
                arr[i] = temp[tempIndex];
                tempIndex++;
            }
        }

        // Time complexity O(dxn)
        // Space complexity O(1)
        public static void LeftRotateArrayByOneDTimes(int[] arr, int d)
        {
            for(int i = 0; i < d; i++)
            {
                LeftRotateArrayByOne(arr);
            }
        }

        public static void LeftRotateArrayByOne(int[] arr)
        {
            int temp = arr[0];
            for(int i = 0; i < arr.Length-1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[arr.Length - 1] = temp;
        }

        //Reversal algorithm for array rotation
        public static void LeftRotateUsingReversalAlgo(int[] arr, int d)
        {
            ReverseArray(arr, 0, d - 1);
            ReverseArray(arr, d, arr.Length - 1);
            ReverseArray(arr, 0, arr.Length - 1);
        }

        public static void ReverseArray(int[] arr, int start, int end)
        {
            while(start < end)
            {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }

        public static int PivotedBinarySearch(int[] arr, int key, int n)
        {
            int pivot = FindPivot(arr, 0, n - 1);

            if (pivot == -1)
                return BinarySearch(arr, key, 0, n - 1);

            if (arr[pivot] == key)
                return pivot;
            if (arr[0] <= key)
                return BinarySearch(arr, key, 0, pivot - 1);

            return BinarySearch(arr, key, pivot + 1, n - 1);
        }
        public static int BinarySearch(int[] arr, int key, int low, int high)
        {
            if(low > high)
            {
                return -1;
            }

            int mid = (low + high) / 2;
            if (arr[mid] == key)
                return mid;
            if (key < arr[mid])
                return BinarySearch(arr, key, low, mid - 1);

            return BinarySearch(arr, key, mid + 1, high);
        }

        public static int FindPivot(int[] arr, int low, int high)
        {
            if (low > high)
                return -1;
            int mid = (low + high) / 2;

            if (mid < high && arr[mid] > arr[mid + 1])
                return mid;
            if (mid > low && arr[mid] < arr[mid - 1])
                return mid - 1;

            if (arr[low] >= arr[mid])
                return FindPivot(arr, low, mid - 1);
            return FindPivot(arr, mid + 1, high);
        }
    }
}
