public class Solution {
    public int FindDuplicate(int[] nums) {
       int low = 1;
       int high = nums.Length - 1;

       while (low < high){
            int mid = (low + high) /2;
            int count = 0;
            foreach (int num in nums){
                if (num <= mid) count++;
            }

            if (count > mid){
                high = mid;
            }
            else {
                low = mid + 1;
            }
       }
       return low; 
    }
}
