public class Solution {
    public int Trap(int[] height) {
        int[] maxRight = new int[height.Length];
        int[] maxLeft = new int[height.Length];

        maxLeft[0] = height[0];
        for(int i = 1; i < height.Length; i++){
            maxLeft[i] = Math.Max(maxLeft[i-1], height[i]);
        }

        maxRight[height.Length - 1] = height[height.Length - 1];
        for(int i = height.Length - 2; i >= 0; i--){
            maxRight[i] = Math.Max(maxRight[i+1], height[i]);
        }

        int sum = 0;
        for (int i = 0; i < height.Length; i++){
            sum += Math.Max(0, Math.Min(maxRight[i], maxLeft[i]) - height[i]);
        }

        return sum;
    }
}
