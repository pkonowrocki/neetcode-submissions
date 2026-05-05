public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var graph = new List<int>[numCourses];
        for (int i = 0; i<numCourses; i++)
            graph[i] = new List<int>();
        foreach (var pre in prerequisites){
            graph[pre[0]].Add(pre[1]);
        }

        var finished = new HashSet<int>();
        for (int i =0; i<numCourses; i++){
            if(!CanIFinish(i, graph, finished))
                return false;
        }

        return true; 
    }

    bool CanIFinish(int course,
     List<int>[] graph,
     HashSet<int> finished,
     HashSet<int> taking = null)
     {
        if (taking is null) taking = new HashSet<int>();
        if (finished.Contains(course)) return true;

        if (taking.Contains(course))
            return false;
        
        taking.Add(course);
        bool canIFinish = true;
        foreach (var pre in graph[course]){
            canIFinish = canIFinish && CanIFinish(pre, graph, finished, taking);
        }
        
        if (canIFinish){
            taking.Remove(course);
            finished.Add(course);
        } 
        return canIFinish;
    }

}
