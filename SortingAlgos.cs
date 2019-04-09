using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgos
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };

            Console.WriteLine("Selection Sort:");
            SelectionSort(nums);

            Console.WriteLine();
            Console.WriteLine("Bubble Sort:");
            BubbleSort(nums);

            Console.ReadKey();
        }

        private static void SelectionSort(int[] arr)
        {
            for(int i = 0; i < arr.Length-1; i++)
            {
                int min_index = i;
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min_index])
                    {
                        min_index = j;                       
                    }
                }
                
int temp = arr[i];
                arr[i] = arr[min_index];
                arr[min_index] = temp;
            }

            Console.WriteLine(string.Join(",", arr.ToList()));
        }

        private static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i] 
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
}
