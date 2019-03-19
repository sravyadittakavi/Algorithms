using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTilt
{
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

            Node n6 = new Node();
            n6.Val = 6;
            n3.LeftNode = n6;

            int tilt = GetTiltOfBinaryTree(root);
            Console.WriteLine("Tilt value is " + tilt);
            Console.ReadKey();
        }

        public static int GetTiltOfBinaryTree(Node root)
        {
            if(root == null)
            {
                return 0;
            }
            Stack<Node> treeStack = new Stack<Node>();
            int tilt = 0;
            treeStack.Push(root);
            while(treeStack != null && treeStack.Any() && treeStack.Count != 0)
            {
                Node outNode = treeStack.Pop();
                if(outNode != null)
                {
                    int leftVal = outNode.LeftNode==null?0:outNode.LeftNode.Val;
                    int rightVal = outNode.RightNode == null ? 0 : outNode.RightNode.Val;
                    tilt += Math.Abs(leftVal - rightVal);
                    treeStack.Push(outNode.RightNode);
                    treeStack.Push(outNode.LeftNode);
                } 
            }
            return tilt;
        }
    }

    public class Node
    {
        public int Val;
        public Node LeftNode;
        public Node RightNode;
    }
}
