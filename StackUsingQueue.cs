using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackUsingQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack stack = new MyStack();

            stack.Push(1);
            stack.Push(2);
            Console.WriteLine(stack.Top());   // returns 2
            Console.WriteLine(stack.Pop()); // returns 2
            Console.WriteLine(stack.Top());
            stack.Push(3);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Top());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Empty()); // returns false
            Console.ReadKey();
        }
    }

    public class MyStack
    {

        /** Initialize your data structure here. */
        public Queue<int> intQueue;
        public MyStack()
        {
            intQueue = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            intQueue.Enqueue(x);
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {          
            intQueue = new Queue<int>(intQueue.Reverse());           
            int returnValue = intQueue.Dequeue();
            intQueue = new Queue<int>(intQueue.Reverse());
            return returnValue;
        }

        /** Get the top element. */
        public int Top()
        {
            Queue<int> temp = new Queue<int>(intQueue.Reverse());
            return temp.Peek();
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            if (intQueue == null)
                return true;
            else
                return intQueue.Count == 0 ? true : false;
        }
    }
}
