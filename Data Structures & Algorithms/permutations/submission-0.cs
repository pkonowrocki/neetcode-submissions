public class Solution {
    public List<List<int>> Permute(int[] nums) {
        List<List<int>> results = new List<List<int>>();
        Backtrack(results, new List<int>(nums), nums, 0);
        return results;
    }

    private void Backtrack(List<List<int>> results, List<int> currentPath, int[] nums, int start){
        if (start == nums.Length)
            results.Add(new List<int>(currentPath));
    
        for (int i = start; i < nums.Length; i++){
            Swap(currentPath, start, i);
            Backtrack(results, currentPath, nums, start+1);
            Swap(currentPath, i, start);
        }
    }

    private void Swap(List<int> currentPath, int i, int j){
        var temp = currentPath.ElementAt(i);
        currentPath[i] = currentPath[j];
        currentPath[j] = temp;
    }
}
