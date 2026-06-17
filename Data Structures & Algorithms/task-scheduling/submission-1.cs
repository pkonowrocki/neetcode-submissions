public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        var dict = new Dictionary<char, int>();
        foreach (var task in tasks){
            if (dict.ContainsKey(task))
                dict[task]++;
            else
                dict[task] = 1;
        }

        PriorityQueue<(char, int), int> pq = new PriorityQueue<(char, int), int>();
        foreach(var (key, value) in dict){
            pq.Enqueue((key, value), -value);
        }

        int tick = 0;
        PriorityQueue<((char, int), int), int> bench = new PriorityQueue<((char, int), int), int>();
        while (pq.Count > 0 || bench.Count > 0){
            if (pq.Count > 0){
                var task = pq.Dequeue();
                if(task.Item2-1 > 0)
                    bench.Enqueue(((task.Item1, task.Item2-1), tick+n+1), tick+n+1);
            }

            tick++;
            while (bench.Count > 0 && bench.Peek().Item2 == tick){
                var newTask = bench.Dequeue();
                pq.Enqueue(newTask.Item1, -newTask.Item1.Item2);
            }
        }

        return tick;
    }
}
