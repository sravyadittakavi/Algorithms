using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSpanner
{
    class Program
    {
        static void Main(string[] args)
        {
            StockSpanner sp = new StockSpanner();
            Console.WriteLine(sp.Next(100));
            Console.WriteLine(sp.Next(80));
            Console.WriteLine(sp.Next(60));
            Console.WriteLine(sp.Next(70));
            Console.WriteLine(sp.Next(60));
            Console.WriteLine(sp.Next(75));
            Console.WriteLine(sp.Next(85));

            Console.ReadKey();
        }
    }
    
    public class StockSpanner
    {
        public Stack<int> stocks;
        public Stack<int> weights;
        public StockSpanner()
        {
            stocks = new Stack<int>();
            weights = new Stack<int>();
        }

        public int Next(int price)
        {
            int weight = 1;
            while(stocks.Count > 0 && stocks.Peek() <= price)
            {
                stocks.Pop();
                weight += weights.Pop();
            }

            stocks.Push(price);
            weights.Push(weight);

            return weight;
        }
    }
}
