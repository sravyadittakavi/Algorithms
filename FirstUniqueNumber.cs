using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUniqueNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstUnique firstUnique = new FirstUnique(new int[] { 2, 3, 5 });
            Console.WriteLine(firstUnique.ShowFirstUnique()); // return 2
            firstUnique.Add(5);            // the queue is now [2,3,5,5]
            Console.WriteLine(firstUnique.ShowFirstUnique()); // return 2
            firstUnique.Add(2);            // the queue is now [2,3,5,5,2]
            Console.WriteLine(firstUnique.ShowFirstUnique()); // return 3
            firstUnique.Add(3);            // the queue is now [2,3,5,5,2,3]
            Console.WriteLine(firstUnique.ShowFirstUnique()); // return -1

            Console.ReadKey();
        }
    }

    public class FirstUnique
    {
        Queue<int> queue = new Queue<int>();
        Dictionary<int, int> all = new Dictionary<int, int>();

        public FirstUnique(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
                Add(nums[i]);
        }

        public int ShowFirstUnique()
        {
            while (queue.Count > 0 && all[queue.Peek()] > 1)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
                return -1;
            else
                return queue.Peek();
        }

        public void Add(int value)
        {
            if (!all.ContainsKey(value))
            {
                all.Add(value, 1);
                queue.Enqueue(value);
            }
            else
            {
                all[value] = all[value] + 1;
            }
        }
    }
}
