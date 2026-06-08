public class Solution {
    public int MostBooked(int n, int[][] meetings) {
        Array.Sort(meetings, (x,y) => x[0].CompareTo(y[0]));
        int[] meetingCounter = new int[n];
        int[] endingMeeting = new int[n];

        foreach(var meeting in meetings){
            int start = meeting[0];
            int end = meeting[1];
            int earliestEndIdx = 0;
            bool hasFoundRoom = false;
            for(int i=0; i<n; i++){
                if (endingMeeting[earliestEndIdx] > endingMeeting[i])
                    earliestEndIdx = i;

                if(start >= endingMeeting[i]){
                    meetingCounter[i]++;
                    endingMeeting[i] = end;
                    hasFoundRoom = true;
                    break;
                }
            }

            if (!hasFoundRoom){
                endingMeeting[earliestEndIdx] = end + (endingMeeting[earliestEndIdx] - start);
                meetingCounter[earliestEndIdx]++;
            }
        }

        int maxMeetingsIdx = 0;
        for(int i = 1; i < n; i++){
            if (meetingCounter[maxMeetingsIdx] < meetingCounter[i])
                maxMeetingsIdx = i;
        }

        return maxMeetingsIdx;
    }
}