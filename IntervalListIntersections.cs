public class Solution {
    public int[][] IntervalIntersection(int[][] A, int[][] B) {
        int m = A.Length;
        int n = B.Length;
        
        int[][] result;
        List<int[]> tempResult = new List<int[]>();
        
        int i=0, j=0;
        
        while(i<m && j<n){
            int[] a = A[i];
            int[] b = B[j];
            
            // Non overlapping cases
            if(a[1] < b[0]) i++;
            else if(b[1] < a[0]) j++;
            else{
                // Overlapping case
                int start = Math.Max(a[0], b[0]);
                int end = Math.Min(a[1], b[1]);
                
                tempResult.Add(new int[2]{start, end});
               
                if(a[1] < b[1]) i++;
                else if(b[1] < a[1]) j++;
                else{
                    i++;
                    j++;
                } 
            }
        }
        
        result = new int[tempResult.Count][];
        for(int k=0;k<result.Length;k++){
            result[k] = tempResult[k];
        }
        return result;
    }
}