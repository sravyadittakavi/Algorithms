using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeBitwiseAnd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RangeBitwiseAnd(16, 32));
            Console.ReadKey();
        }

        public static int RangeBitwiseAnd(int m, int n)
        {
            // Get the common leftmostbit of the given range
            // For eg. 5, 7, it is bitwise and(101, 110, 111)
            // The common column having 1's is leftmost, which is (100)
            // To get this, shift all digits to right until both of the 
            // numbers are equal, then shift one of it to left, same as
            // the number of right shift times
            int shiftCount = 0;
            while(m != n)
            {
                m >>= 1;
                n >>= 1;
                shiftCount++;
            }

            return m << shiftCount;
        }
    }
}
