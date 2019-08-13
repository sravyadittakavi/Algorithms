using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqrt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(mySqrt(22));//46340-2147395600
            Console.Read();
        }

        static int mySqrt(int x)
        {
            // Square every number and check if product is less than or equal to given no.
            // O(sqrt(n))
            if(x==0 || x == 1)
            {
                return x;
            }
            int i = 1;
            //long y = 1;
            // To avoid overflow, do, i<=x/i, instead of i*i <= x
            while (i <= x/i)
            {
                if (i == x/i)
                {
                    return i;
                }
                i++;
                //y = i * i;
            }
            return i - 1;
        }
    }
}
