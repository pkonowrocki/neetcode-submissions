public class Solution {
    public int NumIslands(char[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;
        bool[][] visited = new bool[n][];
        for (int i = 0; i < n; i++)
            visited[i] = new bool[m];

        int numOfIslands = 0;

        for (int i = 0; i < n; i++){
            for (int j = 0; j < m; j++){
                if (visited[i][j]) continue;
                if (grid[i][j] == '1'){
                    numOfIslands++;
                    DFS(i, j, grid, visited);
                }

                visited[i][j] = true;
            }
        }

        return numOfIslands;
    }

    void DFS(int x, int y, char[][] grid, bool[][] visited){
        int n = grid.Length;
        int m = grid[0].Length;
        if (visited[x][y]) return;
        visited[x][y] = true;
        var dirs = new (int dx, int dy)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
        foreach(var (dx, dy) in dirs){
            if (x+dx < n && x+dx >=0
            && y+dy < m && y+dy >=0 &&
            grid[x+dx][y+dy] == '1'){
                DFS(x+dx, y+dy, grid, visited);
            }
        }
    }
}
