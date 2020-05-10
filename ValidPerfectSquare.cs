using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidPerfectSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPerfectSquare(808201));
            Console.ReadKey();
        }

        public static bool IsPerfectSquare(int num)
        {
            if (num == 1)
                return true;

            long left = 2, right = num / 2;

            long mid, square;
            while (left <= right)
            {
                mid = left + (right - left) / 2;

                square = mid * mid;
                if (square == num)
                    return true;
                else if (square > num)
                    right = mid - 1;
                else
                    left = mid + 1;

            }

            return false;
        }
    }
}
