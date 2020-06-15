using System;

public class Solution
{
    public TreeNode SearchBST(TreeNode root, int val)
    {
        while (root != null && val != root.val)
            root = val < root.val ? root.left : root.right;
        return root;
    }
}