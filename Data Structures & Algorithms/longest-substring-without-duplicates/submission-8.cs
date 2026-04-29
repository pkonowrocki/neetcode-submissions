public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s.Length == 0)
            return 0;
        if (s.Length == 1)
            return 1;

        int maxSub = 1;
        
        int start = 0;
        int end = 1;
        
        HashSet<char> letters = new HashSet<char>();
        letters.Add(s[start]);
        while (start < s.Length && end < s.Length){
            if (!letters.Contains(s[end])){
                letters.Add(s[end]);
                end++;
            }
            else{
                if (end-start > maxSub){
                    maxSub = end-start;
                }
                while (letters.Contains(s[end]) ){
                    letters.Remove(s[start]);
                    start++;
                }
                letters.Add(s[end]);
                end++;
            }
        }

        if (end-start > maxSub){
            maxSub = end-start;
        }

        return maxSub;
    }
}
