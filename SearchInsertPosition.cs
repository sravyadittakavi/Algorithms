public class Solution {
    public int SearchInsert(int[] nums, int target) {
        int prevNum = Int32.MinValue;
       
        for(int i=0;i<nums.Length;i++){
            if(nums[i] == target || (target > prevNum && target < nums[i]))
                return i;
            prevNum = nums[i];
        }
        return nums.Length;
    }
}