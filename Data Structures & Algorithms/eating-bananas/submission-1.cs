public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int maxPile = 0;
        foreach(var pile in piles){
            if (pile > maxPile)
                maxPile = pile;
        }
        
        int maxKbound = maxPile;
        int minKbound = 1;
        int k = maxKbound;
        while (maxKbound >= minKbound){
            int mid = (maxKbound+minKbound)/2;
            
            if (CanEatAll(piles, h, mid)){
                maxKbound = mid - 1;
                k = mid;
            }
            else{
                minKbound = mid + 1;
            }
        }
        
        return k;
    }

    private bool CanEatAll(int[] piles, int h, int k) {
        long totalHours = 0; 
        foreach (int pile in piles) {
            totalHours += (pile + k - 1) / k;
        }
        return totalHours <= h;
    }
}
