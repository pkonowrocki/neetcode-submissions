public class Solution {
    public int MostBooked(int n, int[][] meetings) {
        Array.Sort(meetings, (x,y) => x[0].CompareTo(y[0]));
        int[] meetingCounter = new int[n];
        PriorityQueue<int, int> freeRooms = new PriorityQueue<int, int>();
        for(int i = 0; i<n; i++)
            freeRooms.Enqueue(i,i);

        PriorityQueue<(int end, int room), int> busyRooms = new PriorityQueue<(int end, int room), int>();

        foreach(var meeting in meetings){
            int start = meeting[0];
            int end = meeting[1];
            while (busyRooms.Count > 0 && busyRooms.Peek().end <= start){
                var room = busyRooms.Dequeue();
                freeRooms.Enqueue(room.room, room.room);
            }

            if (freeRooms.Count == 0){
                var room = busyRooms.Dequeue();
                end = end + (room.end - start);
                freeRooms.Enqueue(room.room, room.room);
            }

            var roomidx = freeRooms.Dequeue();
            meetingCounter[roomidx]++;
            busyRooms.Enqueue((end, roomidx), end*1000+roomidx);
        }

        int maxMeetingsIdx = 0;
        for(int i = 1; i < n; i++){
            if (meetingCounter[maxMeetingsIdx] < meetingCounter[i])
                maxMeetingsIdx = i;
        }

        return maxMeetingsIdx;
    }
}