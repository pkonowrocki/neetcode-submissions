public class Solution {
    public bool CanJump(int[] nums) {
        bool[] dp = new bool[nums.Length];
        dp[0] = true;
        for (int i = 0; i < nums.Length; i++){
            if (dp[i]){
                var maxJump = nums[i];
                for (int j = 0; j <= maxJump; j++){
                    if (j+i < nums.Length)
                        dp[i+j] = true;
                }
            }
        }

        return dp[nums.Length - 1];
    }
}
