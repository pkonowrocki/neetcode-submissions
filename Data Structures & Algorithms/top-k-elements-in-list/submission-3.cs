public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var dict = new Dictionary<int, int>();
        foreach (var num in nums){
            if (dict.ContainsKey(num)) dict[num]++;
            else dict[num] = 1;
        }

        var pq = new PriorityQueue<int, int>(k);
        foreach(var (num, freq) in dict){
            pq.Enqueue(num, freq);
            if (pq.Count > k) pq.Dequeue();
        }

        return pq.UnorderedItems.Select(x => x.Element).ToArray();
    }
}
