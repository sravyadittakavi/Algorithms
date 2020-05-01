using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckValidSequencePath
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(0);
            root.left = new TreeNode(1);
            root.left.left = new TreeNode(0);
            root.left.left.right = new TreeNode(1);
            root.left.right = new TreeNode(1);
            root.left.right.left = new TreeNode(0);
            root.left.right.right = new TreeNode(0);
            root.right = new TreeNode(0);
            root.right.left = new TreeNode(0);

            Console.WriteLine(IsValidSequence(root, new int[] { 0, 1, 1, 1 }));
            Console.ReadKey();
        }

        public static bool IsValidSequence(TreeNode root, int[] arr)
        {
            if (root == null)
                return arr.Length == 0;
            return IsValid(root, arr, 0);
        }

        public static bool IsValid(TreeNode root, int[] arr, int index)
        {
            if (root.val != arr[index])
                return false;
            if (index == arr.Length - 1)
                return root.left == null && root.right == null;
           
            return (root.left != null && IsValid(root.left, arr, index + 1)) ||
                (root.right != null && IsValid(root.right, arr, index + 1));           
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
