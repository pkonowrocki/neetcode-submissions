public class Solution {
    public int UniquePaths(int m, int n) {
        int[][] dp = new int[m][];
        for (int i = 0; i < m; i++){
            dp[i] = new int[n];
            Array.Fill(dp[i], -1);
        }

        return MoveAndFillUniquePaths(0,0,m,n,dp);
    }

    private int MoveAndFillUniquePaths(int x, int y, int m, int n, int[][] dp){
        if (x == m-1 && y == n-1) return 1;

        if (x >= m || y >= n) return 0;

        if (dp[x][y] != -1) return dp[x][y];

        int down = MoveAndFillUniquePaths(x+1, y, m, n, dp);
        int right = MoveAndFillUniquePaths(x, y+1, m, n, dp);

        dp[x][y] = down+right;

        return dp[x][y];
    }
}
