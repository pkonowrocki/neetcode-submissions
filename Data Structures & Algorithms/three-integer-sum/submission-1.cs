public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        var result = new List<List<int>>();
        int n = nums.Length;

        if (n < 3){
            return result;
        }

        Array.Sort(nums);

        for (int i = 0; i < n-2; i++){
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            int target = -nums[i];
            int j = i+1;
            int k = n-1;
            while (j < k){
                if (target == nums[j] + nums[k]){
                    result.Add(new List<int>(){ nums[i], nums[j], nums[k] });
                    while (j < k && nums[j] == nums[j+1]) j++;
                    while (j < k && nums[k] == nums[k-1]) k--;
                    j++;
                    k--;
                }
                else if (target > nums[j] + nums[k]){
                    j++;
                }
                else{
                    k--;
                }
            }
        }

        // for (int i = 0; i < n-2; i++){
        //     for (int j = i+1; j < n-1; j++){
        //         for (int k = j+1; k < n; k++){
        //             if (nums[i] + nums[j] + nums[k] == 0)
        //                 result.Add(new List<int>(){ nums[i], nums[j], nums[k] });
        //         }
        //     }
        // }

        return result;
    }
}
