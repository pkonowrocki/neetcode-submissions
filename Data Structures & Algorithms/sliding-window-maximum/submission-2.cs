public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        LinkedList<int> queue = new LinkedList<int>();
        List<int> result = new List<int>();

        for (int i = 0; i < k; i++){
            while(queue.Count > 0 && nums[queue.Last.Value] <= nums[i])
                queue.RemoveLast();
            queue.AddLast(i);
        }
        result.Add(nums[queue.First.Value]);

        int idx = k;
        while (idx < nums.Length){
            while(queue.Count > 0 && nums[queue.Last.Value] <= nums[idx])
                queue.RemoveLast();
            while(queue.Count > 0 && queue.First.Value <= idx - k)
                queue.RemoveFirst();

            queue.AddLast(idx);
            result.Add(nums[queue.First.Value]);
            idx++;
        }

        return result.ToArray();
    }
}
