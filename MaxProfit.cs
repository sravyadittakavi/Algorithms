using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxProfit1
{
    class MaxProfit
    {
        static void Main(string[] args)
        {
            int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine(GetMaxProfitWithSingleTransaction(prices));
            Console.WriteLine(GetMaxProfitWithMultipleTransactions(prices));
            Console.ReadKey();
        }

        public static int GetMaxProfitWithSingleTransaction(int[] prices)
        {
            int max_profit = 0, min_price = Int32.MaxValue;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] <= min_price)
                {
                    min_price = prices[i];
                }
                else
                {
                    if (prices[i] - min_price > max_profit)
                        max_profit = prices[i] - min_price;
                }
            }
            return max_profit;
        }

        public static int GetMaxProfitWithMultipleTransactions(int[] prices)
        {
            int max_profit = 0;
            for(int i = 0; i < prices.Length-1; i++)
            {
                if(prices[i] < prices[i + 1])
                {
                    max_profit += prices[i + 1] - prices[i];
                }
            }
            return max_profit;
        }
    }
}
