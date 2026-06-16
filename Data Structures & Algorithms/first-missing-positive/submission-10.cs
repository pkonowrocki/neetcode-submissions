public class Solution {
    public int FirstMissingPositive(int[] nums) {
        for(int i = 0; i < nums.Length; i++){
            var idx = i;
            while (nums[idx] > 0 && nums[idx] <= nums.Length &&  nums[i] != nums[nums[i] - 1]){
                Swap(nums, idx, nums[idx]-1);
            }
        }

        for(int i = 0; i < nums.Length; i++){
            if (i+1 != nums[i])
                return i+1;
        }

        return nums.Length+1;
    }

    private void Swap(int[] nums, int i, int j){
        int t = nums[i];
        nums[i] = nums[j];
        nums[j] = t;
    }
}