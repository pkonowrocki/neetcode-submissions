public class Solution {
    public string MinRemoveToMakeValid(string s) {
        var sb = new StringBuilder();
        int countOpen = 0;
        foreach(var c in s){
            if (c == '('){
                countOpen++;
                sb.Append(c);
            }
            else if (c == ')'){
                if (countOpen > 0){
                    sb.Append(c);
                    countOpen--;
                }
            }
            else{
                sb.Append(c);
            }
        }

        var result = new StringBuilder();
        string intermediate = sb.ToString();

        for (int i = intermediate.Length - 1; i >= 0; i--) {
            char c = intermediate[i];
            
            if (c == '(' && countOpen > 0) {
                countOpen--;
            }
            else {
                result.Append(c);
            }
        }

        char[] finalChars = result.ToString().ToCharArray();
        Array.Reverse(finalChars);
        return new string(finalChars);
    }
}
