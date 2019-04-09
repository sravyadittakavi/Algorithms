using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterTrapping
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] height = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            int result = Trap(height);
            Console.WriteLine("No. of units of water trapped: " + result);
            Console.ReadKey();
        }

        private static int Trap(int[] height)
        {
            int result = 0;
            int max_left = 0, max_right = 0;

            for(int i=1;i<height.Length - 1; i++)
            {
                max_left = 0;
                max_right = 0;
                for(int j = i; j >= 0; j--)
                {
                    if(height[j] > max_left)
                    {
                        max_left = height[j];
                    }
                }

                for(int j = i; j < height.Length; j++)
                {
                    if(height[j] > max_right)
                    {
                        max_right = height[j];
                    }
                }

                result += Math.Min(max_left, max_right) - height[i];
            }

            return result;

        }
    }
}
