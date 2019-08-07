using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresOfSortedArray
{
    class SquaresOfSortedArray
    {
        static void Main(string[] args)
        {
            int[] a = new int[]{-1 };
            int[] result = SortedSquares(a);
            Console.WriteLine(String.Join(",", result));
            Console.ReadKey();
        }

        public static int[] SortedSquares(int[] A)
        {
            if (A.Length > 0)
            {
                int i = 0, j = 0, n = A.Length;
                while (i < A.Length && A[i] < 0)
                {
                    i++;
                }
                j = i - 1;

                int[] ans = new int[n];
                int k = 0;
                while (i < n && j>= 0)
                {
                    if (A[i] * A[i] < A[j] * A[j])
                    {
                        ans[k] = A[i] * A[i];
                        i++;
                    }
                    else
                    {
                        ans[k] = A[j] * A[j];
                        j--;
                    }
                    k++;
                }
                while (i < n)
                {
                    ans[k++] = A[i]*A[i];
                    i++;
                }
                while (j >= 0)
                {
                    ans[k++] = A[j]*A[j];
                    j--;
                }
                return ans;
            }
            //if (A.Length > 0)
            //{
            //    int size = A.Length;
            //    int i = 0, j = size - 1;
            //    while (j >= 0 && i <= j)
            //    {
                   
            //        if(A[i]*A[i] > A[j] * A[j])
            //        {
            //            Swap(A, i, j);                           
            //        }
            //        A[j] = A[j] * A[j];
            //        j--;                
            //    }
            //}
            return A;
        }

        private static void Swap(int[] A, int i, int j)
        {
            int temp;
            temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }
    }
}
