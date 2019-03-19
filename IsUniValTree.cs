using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniValuedTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create tree
            TreeNode root = new TreeNode(1);
           
            TreeNode n2 = new TreeNode(1);           
            root.left = n2;

            TreeNode n3 = new TreeNode(1);            
            root.right = n3;

            TreeNode n4 = new TreeNode(1);          
            n2.left = n4;

            TreeNode n5 = new TreeNode(1);           
            n2.right = n5;

            Console.WriteLine(IsUnivalTree(root));
            Console.ReadKey();
        }

        public static bool IsUnivalTree(TreeNode root)
        {
            Stack<TreeNode> treeStack = new Stack<TreeNode>();
            treeStack.Push(root);
            int rootVal = root.val;
            while(treeStack != null && treeStack.Count != 0)
            {
                TreeNode curr = treeStack.Pop();
                if (curr != null)
                {
                    if (curr.val != rootVal)
                    {
                        return false;
                    }
                    treeStack.Push(curr.right);
                    treeStack.Push(curr.left);
                }
            }
            return true;
        }
    }

    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }
}
