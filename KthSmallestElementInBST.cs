using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KthSmallestElementInBST
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(1);
            root.left.right = new TreeNode(2);
            root.right = new TreeNode(4);

            Console.WriteLine(KthSmallest(root, 2));
            Console.ReadLine();
        }

        public static int KthSmallest(TreeNode root, int k)
        {
            // Inorder traversal of BST gives an array in ascending order.
            // Get element at (k-1)th index from this array
            List<int> arr = new List<int>();
            arr = InOrder(root, arr);
            return arr[k - 1];
        }

        private static List<int> InOrder(TreeNode root, List<int> arr)
        {
            if (root == null)
                return arr;
            InOrder(root.left, arr);
            arr.Add(root.val);
            InOrder(root.right, arr);
            return arr;
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
