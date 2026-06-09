public class Solution {
    public bool Exist(char[][] board, string word) {
        for(int i = 0; i < board.Length; i++){
            for(int j = 0; j < board[0].Length; j++){
                if (Dfs(board, word, 0, i, j))
                    return true;
            }
        }

        return false;
    }

    bool Dfs(char[][] board, string word, int idx, int x, int y){
        if (board[x][y] != word[idx]) return false;
        if (idx == word.Length - 1) return true;

        char org = board[x][y];
        board[x][y] = '#';

        foreach(var (dx, dy) in new (int dx, int dy)[] { (-1, 0), (1, 0), (0, 1), (0, -1) }){
            int nx = x+dx;
            int ny = y+dy;

            if (0 <= nx && nx < board.Length &&
                0 <= ny && ny < board[0].Length &&
                board[nx][ny] != '#')
                if(Dfs(board, word, idx+1, nx, ny))
                    return true;
        }

        board[x][y] = org;
        return false;
    }
}
