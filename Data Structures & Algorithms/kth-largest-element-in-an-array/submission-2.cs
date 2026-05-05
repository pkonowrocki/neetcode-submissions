public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        var heap = new PriorityQueue<int, int>(k);
        foreach (var num in nums){
            if (heap.Count < k || num > heap.Peek()){
                if (heap.Count == k) heap.Dequeue();
                heap.Enqueue(num, num);
            }
        }

        return heap.Peek();
    }
}
