public class Solution {
    public int MaxArea(int[] heights) {
        int start = 0;
        int end = heights.Length-1;
        int maxArea = 0;
        do{
            var newArea = Area(heights, start, end);
            if (maxArea < newArea){
                maxArea = newArea;
            }

            if (heights[start] < heights[end]){
                start++;
            }
            else{
                end--;
            }
        }while(start != end);

        return maxArea;
    }

    private int Area(int[] heights, int left, int right){
        if (left < right)
            return (heights[left] < heights[right] ? heights[left] : heights[right])*(right - left); 
        else
            return (heights[left] < heights[right] ? heights[left] : heights[right])*(left - right);
    }
}
