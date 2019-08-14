using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideWithoutDivideOperator
{
    class DivideWithoutOperator
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DivideUsingBitOperator(-2147483648, -1));//-2147483648
            Console.ReadKey();
        }

        /// <summary>
        /// Divide without /, *, or mod operators, this approach is timing out 
        /// in Leetcode
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        private static int Divide(int dividend, int divisor)
        {
            int quotient = 0;
            int sign = (dividend < 0 ^ divisor < 0) ? -1 : 1;

            long dr = Math.Abs((long)divisor);
            long dd = Math.Abs((long)dividend);

            if (dividend == Int32.MaxValue && divisor == -1)
            {
                return Int32.MaxValue;
            }
            else if (dividend == Int32.MinValue && divisor == -1)
            {
                return Int32.MaxValue;
            }

            // Keep subtracting divisor from dividend until dividend > divisor
            while (dd >= dr)
            {
                dd -= dr;
                quotient++;          
            }

            return quotient * sign;
        }

        /// <summary>
        /// This approach is accepted - using bit operator.
        /// Left shift multiples by 2. so keep shifting left the divisor
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        private static int DivideUsingBitOperator(int dividend, int divisor)
        {
            // Suppose dividend = 15 and divisor = 3, 15 - 3 > 0.We now try to subtract 
            // more by shifting 3 to the left by 1 bit(6).Since 15 - 6 > 0, shift 6 again
            // to 12.Now 15 - 12 > 0, shift 12 again to 24, which is larger than 15.So we
            // can at most subtract 12 from 15.Since 12 is obtained by shifting 3 to left
            // twice, it is 1 << 2 = 4 times of 3.We add 4 to an answer variable(initialized to be 0). 
            // The above process is like 15 = 3 * 4 + 3.We now get part of the quotient(4), with a remaining dividend 3.

            // Then we repeat the above process by subtracting divisor = 3 from the remaining
            // dividend = 3 and obtain 0.We are done. In this case, no shift happens.We simply
            // add 1 << 0 = 1 to the answer variable.

            // Border case
            if (dividend == Int32.MinValue && divisor == -1)
            {
                return Int32.MaxValue;
            }
            int quotient = 0;
            int sign = (dividend < 0 ^ divisor < 0) ? -1 : 1;

            long dr = Math.Abs((long)divisor);
            long dd = Math.Abs((long)dividend);
          
            while(dd >= dr)
            {
                long temp = dr;
                int k = 1;
                while(temp << 1 <= dd)
                {
                    temp <<= 1;
                    k <<= 1;
                }

                dd -= temp;
                quotient += k;
            }

            return quotient*sign;
        }
    }
}
