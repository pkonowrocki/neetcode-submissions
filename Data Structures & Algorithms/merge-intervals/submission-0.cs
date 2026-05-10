public class Solution {
    public int[][] Merge(int[][] intervals) {

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var results = new List<int[]>() { intervals[0] };
        for (int i = 1; i < intervals.Length; i++){
            var lastInterval = results[results.Count() - 1];
            if (lastInterval[1] < intervals[i][0]){
                results.Add(intervals[i]);
            }
            else{
                lastInterval[1] = Math.Max(lastInterval[1], intervals[i][1]);
            }
        }
        
        return results.ToArray();
    }
}
