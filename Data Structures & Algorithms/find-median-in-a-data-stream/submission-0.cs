public class MedianFinder {

    PriorityQueue<int, int> left = new();
    PriorityQueue<int, int> right = new();

    public MedianFinder() {
        
    }
    
    public void AddNum(int num) {
        if (left.Count > right.Count){
            if (num >= left.Peek())
                right.Enqueue(num, num);
            else{
                left.Enqueue(num, -num);
                var maxLeft = left.Dequeue();
                right.Enqueue(maxLeft, maxLeft);
            }
        }
        else{
            right.Enqueue(num, num);
            var minRight = right.Dequeue();
            left.Enqueue(minRight, -minRight);
        }
    }
    
    public double FindMedian() {
        if (left.Count > right.Count)
            return left.Peek();
        else
            return left.Peek() + (right.Peek() - left.Peek())/2.0;
    }
}
