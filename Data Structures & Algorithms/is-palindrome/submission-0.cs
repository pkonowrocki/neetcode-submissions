public class Solution {
    public bool IsPalindrome(string s) {
        int left = 0, right = s.Length-1;
        while (right >= left){
            char start = s[left];
            char end = s[right];
            if (!Char.IsLetterOrDigit(start) || !Char.IsLetterOrDigit(end)){
                if(!Char.IsLetterOrDigit(start))
                    left++;
                if(!Char.IsLetterOrDigit(end))
                    right--;
                continue;
            }

            if (Char.ToLower(start) != Char.ToLower(end)){
                return false;
            }
            else{
                left++;
                right--;
            }
        }

        return true;
    }
}
