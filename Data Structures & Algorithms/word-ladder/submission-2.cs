public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        bool isEndWordInList = false;
        var dict = new Dictionary<string, List<string>>();

        foreach(var word in wordList){
            if (word == endWord) isEndWordInList = true;
            char[] chars = word.ToCharArray();
            for(int i = 0; i < chars.Length; i++){
                char rep = chars[i];
                chars[i] = '*';
                var key = new string(chars);
                if (!dict.ContainsKey(key)){
                    dict[key] = new List<string>();
                }
                dict[key].Add(word);

                chars[i] = rep;
            }
        }

        if (!isEndWordInList) return 0;

        int step = 1;
        Queue<string> queue = new Queue<string>();
        HashSet<string> visited = new HashSet<string>();
        queue.Enqueue(beginWord);
        visited.Add(beginWord);

        while(queue.Count > 0){
            var levelSize = queue.Count;
            for (int idx = 0; idx < levelSize; idx++){
                var word = queue.Dequeue();
                if (word == endWord) return step;
                char[] chars = word.ToCharArray(); 
                for(int i = 0; i < chars.Length; i++){
                    char rep = chars[i];
                    chars[i] = '*';
                    var wildcardWord = new string(chars); 
                    dict.TryGetValue(wildcardWord, out var next);
                    foreach (var nextWord in (next ?? new List<string>()).Where(w => !visited.Contains(w))){
                        queue.Enqueue(nextWord);
                        visited.Add(nextWord);
                    }
                    chars[i] = rep;
                }
            }
            step++;
        }

        return 0;
    }
}
