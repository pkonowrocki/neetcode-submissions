public class MinStack {

    Stack<int> stack = new Stack<int>();
    Stack<int> min = new Stack<int>();

    public MinStack() {

    }
    
    public void Push(int val) {
        stack.Push(val);
        if (min.Count() > 0)
            min.Push(Math.Min(min.Peek(), val));
        else
            min.Push(val);
    }
    
    public void Pop() {
        stack.Pop();
        min.Pop();
    }
    
    public int Top() {
        return stack.Peek();
    }
    
    public int GetMin() {
        return min.Peek();
    }
}
