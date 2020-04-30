using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumPathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(-10);
            root.left = new TreeNode(9);
            TreeNode node1 = new TreeNode(20);
            node1.left = new TreeNode(15);
            node1.right = new TreeNode(7);
            root.right = node1;

            Console.WriteLine(MaxPathSum(root));
            Console.ReadKey();
        }

        static int maxSum = Int32.MinValue;

        public static int MaxPathSum(TreeNode root)
        {
            MaxGain(root);
            return maxSum;
        }

        public static int MaxGain(TreeNode node)
        {
            if (node == null) return 0;

            // max sum on the left and right sub-trees of node
            int leftGain = Math.Max(MaxGain(node.left), 0);
            int rightGain = Math.Max(MaxGain(node.right), 0);

            // the price to start a new path where `node` is a highest node
            int priceNewpath = node.val + leftGain + rightGain;

            // update max_sum if it's better to start a new path
            maxSum = Math.Max(maxSum, priceNewpath);

            // for recursion :
            // return the max gain if continue the same path
            return node.val + Math.Max(leftGain, rightGain);
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
