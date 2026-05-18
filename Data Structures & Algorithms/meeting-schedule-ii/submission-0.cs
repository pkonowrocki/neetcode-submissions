/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public int MinMeetingRooms(List<Interval> intervals) {
        
        intervals = intervals.OrderBy(x => x.start).ToList();
        var queue = new PriorityQueue<Interval, int>();

        foreach(var interval in intervals){
            if (queue.Count == 0)
                queue.Enqueue(interval, interval.end);
            else{
                if (interval.start >= queue.Peek().end){
                    queue.Dequeue();
                }

                queue.Enqueue(interval, interval.end);
            }
        }

        return queue.Count;
    }
}
