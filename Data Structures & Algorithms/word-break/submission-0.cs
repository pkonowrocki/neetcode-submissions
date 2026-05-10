public class Solution {
    public bool WordBreak(string s, List<string> wordDict) {
        
        bool[] dp = new bool[s.Length+1];
        dp[0] = true;
        int lastMatchedIdx = 0;
        for (int i = 1; i <= s.Length; i++){
            foreach (var word in wordDict){
                if (i >= word.Length){
                    if (dp[i - word.Length] == true && s.Substring(i - word.Length, word.Length) == word) {
                        dp[i] = true;
                        break;
                    }
                }
            }
        }

        return dp[s.Length];
    }
}
