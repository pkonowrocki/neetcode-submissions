public class Solution {
    public int MaxProfit(int[] prices) {
        int n = prices.Length;
        int min = prices[0];
        int maxReturn = 0;
        for(int i = 1; i < n; i++){
            if (prices[i] - min > maxReturn)
                maxReturn = prices[i] - min;

            if (prices[i] < min)
                min = prices[i];
        }

        return maxReturn;
    }
}
