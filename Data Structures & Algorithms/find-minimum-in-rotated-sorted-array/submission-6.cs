public class Solution {
    public int FindMin(int[] nums) {
        int l = 0, r = nums.Length-1;

        int min = nums[l];

        while (l <= r){
            if (nums[l] < nums[r]){
                min = Math.Min(min, nums[l]);
                break;
            }

            int m = l + (r-l)/2;
            min = Math.Min(min, nums[m]);
            if (nums[m] >= nums[l]){
                l = m+1;
            }
            else{
                r = m-1;
            }
        }

        return min;
    }
}
