using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBFSAndDFS
{
    /// <summary>
    /// Breadth and Depth First Tree Search
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Create tree
            Node root = new Node();
            root.Val = 1;

            Node n2 = new Node();
            n2.Val = 2;
            root.LeftNode = n2;

            Node n3 = new Node();
            n3.Val = 3;
            root.RightNode = n3;

            Node n4 = new Node();
            n4.Val = 4;
            n2.LeftNode = n4;

            Node n5 = new Node();
            n5.Val = 5;
            n2.RightNode = n5;

            // Breadth First Search
            Console.WriteLine("Breadth First Search Result:");
            List<int> result = BreadthFirstSearch(root);
            foreach(int i in result)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("");
            Console.WriteLine("");

            // Depth First Search
            Console.WriteLine("Depth First Search Result:");
            result = DepthFirstSearch(root);
            foreach (int i in result)
            {
                Console.Write(i + " ");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Breadth First Search using Queue
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<int> BreadthFirstSearch(Node root)
        {
            List<int> result = new List<int>();
            Queue<Node> intQueue = new Queue<Node>();
            intQueue.Enqueue(root);
            while(intQueue != null && intQueue.Any()){
                Node n1 = intQueue.Dequeue();
                if (n1 != null)
                {
                    result.Add(n1.Val);
                    if(n1.LeftNode != null)
                        intQueue.Enqueue(n1.LeftNode);
                    if (n1.RightNode != null)
                        intQueue.Enqueue(n1.RightNode);
                }
            }
            return result;
        }

        /// <summary>
        /// Depth First Search using Stack
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<int> DepthFirstSearch(Node root)
        {
            List<int> result = new List<int>();
            Stack<Node> intStack = new Stack<Node>();
            intStack.Push(root);
            while (intStack != null && intStack.Any())
            {
                Node n1 = intStack.Pop();
                if (n1 != null)
                {
                    result.Add(n1.Val);
                    if (n1.RightNode != null)
                        intStack.Push(n1.RightNode);
                    if (n1.LeftNode != null)
                        intStack.Push(n1.LeftNode);
                }
            }
            return result;
        }
    }

    public class Node
    {
        public Node LeftNode;
        public int Val;
        public Node RightNode;
    }
}
