using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvertABinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(4);
            root.left = new TreeNode(2, new TreeNode(1), new TreeNode(3));
            root.right = new TreeNode(7, new TreeNode(6), new TreeNode(9));

            root = InvertTree(root);
            Console.WriteLine(root.val);
            Console.ReadLine();
        }

        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;
            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(root);

            while (nodeQueue.Count != 0)
            {
                TreeNode current = nodeQueue.Dequeue();
                TreeNode temp = current.left;
                current.left = current.right;
                current.right = temp;
                if (current.left != null) nodeQueue.Enqueue(current.left);
                if (current.right != null) nodeQueue.Enqueue(current.right);
            }

            return root;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
