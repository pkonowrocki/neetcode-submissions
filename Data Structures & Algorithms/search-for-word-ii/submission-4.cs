public class Solution {
    public class Trie{
        public Dictionary<char, Trie> next = new();
        public bool isEnd = false;
    }
    
    public List<string> FindWords(char[][] board, string[] words) {
        var main = new Trie();

        foreach(var w in words){
            var curr = main;
            foreach(var c in w){
                if (!curr.next.ContainsKey(c))
                    curr.next[c] = new Trie();
                curr = curr.next[c];
            }
            curr.isEnd = true;
        }

        int n = board.Length, m = board[0].Length;
        List<string> results = new List<string>();
        for(int i = 0; i < n; i++){
            for(int j = 0; j < m; j++){
                if(main.next.ContainsKey(board[i][j])){
                    List<char> sb = new List<char>() {board[i][j]};
                    List<string> result = new List<string>();
                    char a = board[i][j];
                    board[i][j] = '#';
                    FindWord(board, main.next[a], i, j, sb, result);
                    board[i][j] = a;
                    results.AddRange(result);
                }
            }    
        }

        return results;
    }

    private void FindWord(char[][] board, Trie curr, int i, int j, List<char> sb, List<string> result){
        if (curr.isEnd){
            result.Add(new string(sb.ToArray()));
            curr.isEnd = false;
        }

        if (curr.next.Count == 0)
            return;

        int n = board.Length, m = board[0].Length;
        foreach(var (dx, dy) in new (int, int)[]{(-1, 0), (1, 0), (0, 1), (0, -1)}){
            if(i+dx >=0 && i+dx<n && j+dy>=0 && j+dy<m && board[i+dx][j+dy]!='#'){
                var c = board[i+dx][j+dy];
                if (curr.next.ContainsKey(c)){
                    sb.Add(c);
                    board[i+dx][j+dy] = '#';
                    FindWord(board, curr.next[c], i+dx, j+dy, sb, result);
                    board[i+dx][j+dy] = c;
                    sb.RemoveAt(sb.Count-1);
                }
            }
        } 
    }
}
