public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> results = new List<List<int>>();
        Backtrack(results, new List<int>(), nums, 0);
        return results;
    }

    private void Backtrack(List<List<int>> results, List<int> currentPath, int[] nums, int start){
        results.Add(new List<int>(currentPath));
        for (int i = start; i < nums.Length; i++){
            currentPath.Add(nums[i]);
            Backtrack(results, currentPath, nums, i+1);
            currentPath.RemoveAt(currentPath.Count() - 1);
        }
    }
}
