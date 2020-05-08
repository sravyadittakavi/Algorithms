using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CousinsInABinaryTree
{
    class Program
    {
        static int recordedDepth = -1;
        static bool isCousin = false;
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.right = new TreeNode(4);
            root.right.left = new TreeNode(5);

            Console.WriteLine(IsCousins(root, 4, 5));
            Console.ReadKey();
        }

        public static bool IsCousins(TreeNode root, int x, int y)
        {
            DFS(root, 0, x, y);
            return isCousin;
        }

        private static bool DFS(TreeNode node, int depth, int x, int y)
        {

            if (node == null)
            {
                return false;
            }

            // Don't go beyond the depth restricted by the first node found.
            if (recordedDepth != -1 && depth > recordedDepth)
            {
                return false;
            }

            if (node.val == x || node.val == y)
            {
                if (recordedDepth == -1)
                {
                    // Save depth for the first node found.
                    recordedDepth = depth;
                }
                // Return true, if the second node is found at the same depth.
                return recordedDepth == depth;
            }

            bool left = DFS(node.left, depth + 1, x, y);
            bool right = DFS(node.right, depth + 1, x, y);

            // this.recordedDepth != depth + 1 would ensure node x and y are not
            // immediate child nodes, otherwise they would become siblings.
            if (left && right && recordedDepth != depth + 1)
            {
                isCousin = true;
            }
            return left || right;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
