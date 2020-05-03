public class Solution {
    public int MaxSubArray(int[] nums) {
        int currentSum = nums[0];
        int maximumSum = nums[0];

        for(int i=1;i<nums.Length;i++){
            currentSum = Math.Max(nums[i], currentSum+nums[i]);
            maximumSum = Math.Max(currentSum, maximumSum);
        }

        return maximumSum;
    }
}