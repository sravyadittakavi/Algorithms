using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinStack
{
    class Program
    {
        static void Main(string[] args)
        {
            MinStack obj = new MinStack();
            obj.Push(2147483646);
            obj.Push(2147483646);
            obj.Push(2147483647);
            Console.WriteLine(obj.Top());
            obj.Pop();
            Console.WriteLine(obj.GetMin());
            obj.Pop();
            Console.WriteLine(obj.GetMin());
            obj.Pop();
            obj.Push(2147483647);
            Console.WriteLine(obj.Top());
            Console.WriteLine(obj.GetMin());
            obj.Push(-2147483648);
            Console.WriteLine(obj.Top());
            Console.WriteLine(obj.GetMin());
            obj.Pop();
            Console.WriteLine(obj.GetMin());
            Console.ReadLine();
        }
    }

    public class MinStack
    {
        public Stack<long> myStack;
        public int minElement;
        public MinStack()
        {
            myStack = new Stack<long>();
            minElement = 0;
        }

        public void Push(int x)
        {
            if (myStack.Count == 0)
            {
                myStack.Push(x);
                minElement = x;
            }
            else
            {
               if(x >= minElement)
                {
                    myStack.Push(x);
                }
                else
                {
                    if (x == Int32.MinValue)
                    {                        
                        myStack.Push(x);
                    }
                    else
                    {                        
                        long element = (2 * x) - minElement;
                        myStack.Push(element);
                        minElement = x;
                    }
                }
            }
        }

        public void Pop()
        {
            if(myStack.Count != 0)
            {
                int top = (int)myStack.Pop();               

                if (top < minElement && top != Int32.MinValue)
                {
                    minElement = (2 * minElement) - top;
                }                
            }
        }

        public int Top()
        {
            if (myStack.Count != 0)
            {
                int top = (int)myStack.Peek();
                if (top == Int32.MinValue)
                    return top;
                if (top < minElement)
                {
                    return minElement;
                }
                else
                {
                    return top;
                }
            }
            return 0;
        }

        public int GetMin()
        {
            int top = (int)myStack.Peek();
            if (top == Int32.MinValue)
                return top;
            else
                return minElement;
        }
    }
}
