using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingBits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(",", CountBits(9)));
            Console.ReadLine();
        }

        public static int[] CountBits(int num)
        {
            //  int i = 0, b=1;
            // int[] result = new int[num+1];
            // result[0] = 0;
            // while(b <= num){
            //   while(i < b && i+b <=num){
            //      result[i+b] = result[i]+1;
            //     i++;
            //}
            //i=0;
            //b<<=1; 
            //}
            //return result;

            int[] result = new int[num + 1];
            for (int i = 1; i <= num; i++)
            {
                result[i] = result[i / 2] + (i % 2);// result[i] = result[i>>1]+(i&1);
                // result[i] = result[i&(i-1)]+1;
            }
            return result;
        }
    }
}
