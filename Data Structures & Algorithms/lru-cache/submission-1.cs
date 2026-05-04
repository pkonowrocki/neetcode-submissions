public class LRUCache {
    int _capacity;
    Dictionary<int, LinkedListNode<(int, int)>> _dict;
    LinkedList<(int, int)> _list;

    public LRUCache(int capacity) {
        _capacity = capacity;
        _dict = new Dictionary<int, LinkedListNode<(int, int)>>();
        _list = new LinkedList<(int, int)>();
    }
    
    public int Get(int key) {
        if (_dict.ContainsKey(key)){
            var value = _dict[key];
            _list.Remove(value);
            _list.AddFirst(value);
            return value.Value.Item2;
        }
        else{
            return -1;
        }
    }
    
    public void Put(int key, int value) {
        if (_dict.ContainsKey(key)){
            _list.Remove(_dict[key]);
            _dict.Remove(key);
        }
        else if (_dict.Count >= _capacity){
            var lastNode = _list.Last;
            _list.Remove(lastNode);
            _dict.Remove(lastNode.Value.Item1);
        }

        var newNode = _list.AddFirst((key, value));
        _dict.Add(key, newNode);
    }
}
