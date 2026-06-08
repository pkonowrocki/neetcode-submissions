public class Solution {
    public int ShipWithinDays(int[] weights, int days) {
        int maxWeight = 0;
        foreach (var weight in weights){
            maxWeight = Math.Max(maxWeight, weight);
        }

        int n = weights.Length;
        int upperCapacity = (n/days + 1)*maxWeight;

        int l = 1, r = upperCapacity;
        int minimalCapacity = upperCapacity;
        while (l <= r){
            int m = l + (r-l)/2;
            if (WillManage(weights, days, m)){
                minimalCapacity = Math.Min(minimalCapacity, m);
                r = m-1;
            }
            else{
                l = m+1;
            }
        }

        return minimalCapacity;
    }

    private bool WillManage(int[] weights, int days, int capacity){
        int n = 0;
        for(int i = 0; i < days; i++){
            int dayCapacity = capacity;
            while (dayCapacity >= weights[n]){
                dayCapacity = dayCapacity - weights[n];
                n++;
                if (n == weights.Length) return true;
            }
        }

        return false;        
    }
}