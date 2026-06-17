public class Solution {
    public string foreignDictionary(string[] words) {
        if(words.Length == 1)
            return words[0];

        Dictionary<char, HashSet<char>> graph = new();
        HashSet<char> allChars = new();

        for (int i = 1; i < words.Length; i++){
            var a = words[i-1];
            var b = words[i];
            if (a==b)
                foreach(var c in a)
                    allChars.Add(c);
            if (a.StartsWith(b))
                continue;

            foreach(var c in a)
                allChars.Add(c);
            foreach(var c in b)
                allChars.Add(c);

            int idx = 0;
            while (idx < Math.Min(a.Length, b.Length)){
                if (a[idx] != b[idx])
                    break;
                idx++;
            }

            if (idx == Math.Min(a.Length, b.Length))
                continue;

            if(!graph.ContainsKey(a[idx]))
                graph[a[idx]] = new HashSet<char>();

            graph[a[idx]].Add(b[idx]);
        }

        var startingList = new Queue<char>();
        foreach(var c in allChars)
            if(!graph.ContainsKey(c))
                startingList.Enqueue(c);

        var sb = new List<char>();
        while (startingList.Count > 0){
            var c = startingList.Dequeue();
            sb.Add(c);
            foreach(var (k, v) in graph){
                if (v.Remove(c)){
                    if (v.Count == 0){
                        startingList.Enqueue(k);
                        graph.Remove(k);
                    }
                }
            }
        }

        if (sb.Count == allChars.Count){
            sb.Reverse();
            return new string(sb.ToArray());
        }
        else
            return "";
    }
}
