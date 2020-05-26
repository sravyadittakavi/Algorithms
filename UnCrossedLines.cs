public class Solution {
    public int MaxUncrossedLines(int[] A, int[] B) {
        // Use dynamic programming - similar to longest common subsequence
        int m = A.Length;
        int n = B.Length;
        
        int[,] result = new int[m+1,n+1];
        
        for(int i=1;i<m+1;i++){
            for(int j=1;j<n+1;j++){
                result[i,j] = A[i-1]==B[j-1]?(1+result[i-1,j-1]):Math.Max(result[i-1,j], result[i,j-1]);
            }
        }
        return result[m,n];
    }
}