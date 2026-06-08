public class Solution {
    public bool Search(int[] nums, int target) {
        int l = 0, r = nums.Length-1;
        while (l <= r){
            int m = l + (r-l)/2;
            if (nums[m] == target) return true;

            else if (nums[l] == nums[m] && nums[m] == nums[r]){
                l++;
                r--;
                continue;
            }
            
            else if (nums[m] >= nums[l]){
                if (nums[m] > target && target >= nums[l]){
                    r = m-1;
                }
                else{
                    l = m+1;
                }
            }
            
            else if (nums[m] <= nums[r]){
                if (nums[m] < target && target <= nums[r]){
                    l = m+1;
                }
                else{
                    r = m-1;
                }
            }
        }

        return false;

    }

    public bool BinarySearch(int[] nums, int target, int l, int r){
        while (l <= r){
            int m = l + (r-l)/2;
            if (nums[m] == target)
                return true;
            else if (target > nums[m]){
                l = m+1;
            }
            else{
                r = m-1;
            }
        }
        return false;
    }
}