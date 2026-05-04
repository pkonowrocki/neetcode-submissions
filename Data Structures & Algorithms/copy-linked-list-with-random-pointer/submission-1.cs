/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        if (head==null) return null;
        var dict = new Dictionary<Node, Node>();
        var newHead = new Node(head.val);
        dict.Add(head, newHead);

        var newCurrent = newHead;
        var current = head;
        var next = head.next;
        while (next != null){
            var newNext = new Node(next.val);
            dict.Add(next, newNext);
            newCurrent.next = newNext;

            newCurrent = newCurrent.next;
            current = current.next;
            next = next.next;
        }

        current = head;
        newCurrent = newHead;
        while (current != null){
            if (current.random != null){
                newCurrent.random = dict[current.random];
            }
            
            current = current.next;
            newCurrent = newCurrent.next;
        }
    
        return newHead;
    }
}
