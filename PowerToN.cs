using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerToN
{
    class PowerToN
    {
        static void Main(string[] args)
        {          
            int result = Convert.ToInt32(Power(0.0001, 2147483647));
            Console.WriteLine(result);
            Console.Read();
        }

        static double Power(double x, int n)
        {
            if (n == 0) return 1;
            
            // If n is negative, result is 1/x power n
            if(n < 0 && n != Int32.MinValue)
            {
                n = -n;
                x = 1 / x;
            }

            double y = Power(x, n / 2);
            if (n%2 == 0)
            {                
                return y * y;
            }
            else
            {
                return y * y * x;
            }
        }      
    }
}
