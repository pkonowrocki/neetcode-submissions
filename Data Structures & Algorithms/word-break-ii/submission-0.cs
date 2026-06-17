public class Solution {
    public List<string> WordBreak(string s, List<string> wordDict) {
        List<string>[] dp = new List<string>[s.Length+1];
        dp[0] = new List<string>();

        for (int i = 1; i <= s.Length; i++){
            foreach(var word in wordDict){
                if (i >= word.Length){
                    if (dp[i-word.Length] != null && s.Substring(i-word.Length, word.Length) == word){
                        if (dp[i] is null)
                            dp[i] = new List<string>();
                        dp[i].Add(word);
                    }
                }
            }
        }

        var results = new List<string>();
        Backtrack(dp.Length-1, results, dp, "");
        return results;
    }

    private void Backtrack(int i, List<string> results, List<string>[] dp, string currentSentence){
        if (i == 0){
            results.Add(currentSentence.Trim());
            return;
        }

        foreach(var word in (dp[i] ?? new List<string>())){
            string sentence = word + (currentSentence == "" ? "" : " " + currentSentence);
            Backtrack(i-word.Length, results, dp, sentence);
        }
    }
}