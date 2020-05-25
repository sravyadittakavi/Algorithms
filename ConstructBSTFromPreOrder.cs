public class Solution {
    public TreeNode BstFromPreorder(int[] preorder) {
        TreeNode root = new TreeNode(preorder[0]);
        Stack<TreeNode> st = new Stack<TreeNode>();
        st.Push(root);
        
        for(int i=1;i<preorder.Length;i++){
            TreeNode temp = null;
            
            // Keep on popping while the next value is greater than  
            // stack's top value. 
            while(st.Count > 0 && preorder[i] > st.Peek().val){
                temp = st.Pop();
            }
            
            // Make this greater value as the right child 
            // and push it to the stack  
            if(temp != null){
                temp.right = new TreeNode(preorder[i]);
                st.Push(temp.right);
            }
             // If the next value is less than the stack's top 
            // value, make this value as the left child of the  
            // stack's top node. Push the new node to stack 
            else{
                temp = st.Peek();
                temp.left = new TreeNode(preorder[i]);
                st.Push(temp.left);
            }
        }
        
        return root;
    }
}