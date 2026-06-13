public class Solution {
    public int Trap(int[] height) {
        int r = height.Length - 1;
        int l = 0;

        int maxLeft = height[l];
        int maxRight = height[r];

        int sum = 0;
        while (l < r){
            if(height[l] < height[r]){
                maxLeft = Math.Max(height[l], maxLeft);
                sum += Math.Max(0, maxLeft - height[l]);
                l++;
            }
            else{
                maxRight = Math.Max(height[r], maxRight);
                sum += Math.Max(0, maxRight - height[r]);
                r--;
            }

        }

        return sum;
    }
}
