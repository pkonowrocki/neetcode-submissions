public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int n = matrix.Length;
        int m = matrix[0].Length;
        
        int l = 0, r = To1D(n-1, m-1, matrix);
        while(l <= r){
            int mid = l + (r-l)/2;
            var (x, y) = To2D(mid, matrix);
            int val = matrix[x][y];
            if(val == target){
                return true;
            }
            else if(target > val){
                l = mid + 1;
            }
            else{
                r = mid -1;
            }
        }

        return false;
    }

    int To1D(int i, int j, int[][] matrix){
        int n = matrix[0].Length;
        return i*n + j;
    }

    (int, int) To2D(int i, int[][] matrix){
        int n = matrix[0].Length;
        return (i/n, i%n);
    }
}
