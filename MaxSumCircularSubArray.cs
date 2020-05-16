public class Solution {
    public int MaxSubarraySumCircular(int[] A) {
        // Use kadane's algorithm
        int n = A.Length;
        
        // If all are negative no's, then return max of them
        // No need of Kadane's algorithm
        int maxSoFar = Int32.MinValue;
        bool allNeg = true;
        for(int i=0;i<n;i++){
            if(A[i] >=0){
                allNeg = false;
                break;
            }
            else{
                if(A[i] > maxSoFar){
                    maxSoFar = A[i];
                }
            }
        }
        if(allNeg)
            return maxSoFar;
        
        // Case 1: without wrap
        int maxKadane = Kadane(A);
        
        // Case 2: with wrap
        int maxWrap = 0;
        
        for(int i=0;i<n;i++){
            maxWrap += A[i];// calculate array sum
            A[i] = -A[i];// Invert the array no.s
        }
        
        // max sum with corner elements will be: 
        // array-sum - (-max subarray sum of inverted array)
        maxWrap = maxWrap-(-Kadane(A));
        
        // The maximum circular sum will be maximum of two sums 
        return Math.Max(maxWrap, maxKadane);
    }
    
    public int Kadane(int[] A){
        int n = A.Length;
        int max_so_far =0, max_ending_here = 0;
        for(int i=0;i<n;i++){
            max_ending_here = A[i]+max_ending_here;
            if(max_ending_here < 0)
                max_ending_here = 0;
            else if(max_so_far < max_ending_here)
                max_so_far = max_ending_here;
        }
        return max_so_far;
    }
}