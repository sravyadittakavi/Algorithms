using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingStack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue queue = new MyQueue();

            queue.Push(1);
            queue.Push(2);
            Console.WriteLine(queue.Peek());  // returns 1
            Console.WriteLine(queue.Pop());   // returns 1
            queue.Push(3);
            Console.WriteLine(queue.Peek());  // returns 2
            Console.WriteLine(queue.Pop());   // returns 2
            Console.WriteLine(queue.Pop());   // returns 3
            Console.WriteLine(queue.Empty()); // returns true
            Console.ReadKey();
        }

        public class MyQueue
        {
            public Stack<int> intStack;

            /** Initialize your data structure here. */
            public MyQueue()
            {
                intStack = new Stack<int>();
            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {
                intStack.Push(x);
            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                intStack = ReverseStack(intStack);
                int returnValue = intStack.Pop();
                intStack = ReverseStack(intStack); 
                return returnValue;
            }

            /** Get the front element. */
            public int Peek()
            {
                intStack = ReverseStack(intStack);
                int returnValue = intStack.Peek();
                intStack = ReverseStack(intStack);
                return returnValue;
            }

            private Stack<int> ReverseStack(Stack<int> stack)
            {
                Stack<int> temp = stack;
                Stack<int> revStack = new Stack<int>();
                while (temp.Count != 0)
                {
                    revStack.Push(temp.Pop());
                }
                return revStack;
            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                if (intStack == null)
                    return true;
                else
                {
                    return intStack.Count == 0 ? true : false;
                }
            }
        }
    }
}
