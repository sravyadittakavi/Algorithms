using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTFromPreOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] preorder = new int[] { 8, 5, 1, 7, 10 };
            var node = BstFromPreorder(preorder);
            Console.ReadKey();
        }

        public static TreeNode BstFromPreorder(int[] preorder)
        {
            int n = preorder.Length;
            if (n == 0)
                return null;

            TreeNode root = new TreeNode(preorder[0]);
            Stack<TreeNode> nodeStack = new Stack<TreeNode>();
            nodeStack.Push(root);

            for(int i = 1; i < n; i++)
            {
                // Take the last element of the stack as a parent
                // and create a child from the next preorder element
                TreeNode node = nodeStack.Peek();
                TreeNode child = new TreeNode(preorder[i]);

                // Keep popping the stack until its top value is greater than current preorder element
                // to get the current parent
                while (nodeStack.Count > 0 && nodeStack.Peek().val < child.val)
                    node = nodeStack.Pop();

                if (node.val < child.val)
                    node.right = child;
                else
                    node.left = child;

                nodeStack.Push(child);
            }

            return root;
        }
    }

 
 //Definition for a binary tree node.
 public class TreeNode
  {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int x) { val = x; }
 }

}
