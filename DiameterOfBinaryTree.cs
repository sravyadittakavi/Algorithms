    /* Method to calculate the diameter and return it to main */
    int Diameter(Node root) 
    { 
        /* base case if tree is empty */
        if (root == null) 
            return 0; 
  
        /* get the height of left and right sub trees */
        int lheight = Height(root.left); 
        int rheight = Height(root.right); 
  
        /* get the diameter of left and right subtrees */
        int ldiameter = Diameter(root.left); 
        int rdiameter = Diameter(root.right); 
  
        /* Return max of following three 
          1) Diameter of left subtree 
         2) Diameter of right subtree 
         3) Height of left subtree + height of right subtree + 1 */
        return Math.Max(lheight + rheight + 1, 
                        Math.Max(ldiameter, rdiameter)); 
  
    } 
  
    /* A wrapper over diameter(Node root) */
    int Diameter() 
    { 
        return Diameter(root); 
    } 
  
    /*The function Compute the "height" of a tree. Height is the 
      number f nodes along the longest path from the root node 
      down to the farthest leaf node.*/
    static int Height(Node node) 
    { 
        /* base case tree is empty */
        if (node == null) 
            return 0; 
  
        /* If tree is not empty then height = 1 + max of left 
           height and right heights */
        return (1 + Math.Max(Height(node.left), Height(node.right))); 
    } 