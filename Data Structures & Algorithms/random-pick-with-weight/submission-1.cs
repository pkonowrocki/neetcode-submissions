public class Solution {

    int[] sums;
    int sum;
    Random rnd = new Random();
    public Solution(int[] w) {
        sums = new int[w.Length];
        sum = 0;
        for(int i = 0; i < w.Length; i++){
            sum += w[i];
            sums[i] = sum;
        }
    }
    
    public int PickIndex() {
        int num = rnd.Next(0, sum);
        int l = 0, r = sums.Length-1;
        int idx = 0;
        while(l<=r){
            int m = l + (r-l)/2;
            if (sums[m] > num){
                idx = m;
                r = m-1;
            }
            else{
                l = m+1;
            }
        }
        return idx;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */