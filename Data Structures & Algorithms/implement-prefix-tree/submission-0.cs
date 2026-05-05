public class PrefixTree {
    Dictionary<char, PrefixTree> next = new Dictionary<char, PrefixTree>();
    bool wordEnd = false;
    
    public PrefixTree() {
        
    }
    
    public void Insert(string word) {
        var current = this;
        for (int i = 0; i < word.Length; i++){
            char c = word[i];

            if (!current.next.ContainsKey(c)){
                current.next[c] = new PrefixTree();
            }
            
            current = current.next[c];
        }

        current.wordEnd = true;
    }
    
    public bool Search(string word) {
        var current = this;
        foreach (char c in word){
            if (!current.next.TryGetValue(c, out var next))
                return false;
            current = next;
        }

        return current.wordEnd;
    }
    
    public bool StartsWith(string prefix) {
        var current = this;
        foreach (char c in prefix){
            if (!current.next.TryGetValue(c, out var next))
                return false;
            current = next;
        }

        return true;
    }
}
