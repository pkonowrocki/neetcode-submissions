public class Solution {
    public int LongestIncreasingPath(int[][] matrix) {
        int[][] cache = new int[matrix.Length][];
        for(int i = 0; i < matrix.Length; i++){
            cache[i] = new int[matrix[i].Length];
            for (int j = 0; j < matrix[i].Length; j++){
                cache[i][j] = -1;
            }
        }
        int max = -1;
        for (int x = 0; x < matrix.Length; x++){
            for (int y = 0; y < matrix[x].Length; y++){
                max = Math.Max(max, DFS(matrix, ref cache, x, y));
            }
        }

        return max;
    }

    private int DFS(int[][] matrix, ref int[][] cache, int x, int y){
        if (cache[x][y] >= 0) {
            return cache[x][y];
        }

        (int dx, int dy)[] dirs = new (int dx, int dy)[4] {(1, 0), (-1, 0), (0, 1), (0, -1)};
        int max = 1;
        foreach ((int dx, int dy) in dirs){
            if (x+dx >=0 && x+dx < matrix.Length &&
                y+dy >= 0 && y+dy < matrix[x].Length &&
                matrix[x+dx][y+dy] > matrix[x][y]){
                    max = Math.Max(max, DFS(matrix, ref cache, x+dx, y+dy)+1);
                }
        } 
        cache[x][y] = max;

        return max;
    }
}
