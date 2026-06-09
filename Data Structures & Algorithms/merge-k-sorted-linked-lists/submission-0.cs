/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {    
    public ListNode MergeKLists(ListNode[] lists) {
        PriorityQueue<ListNode, int> queue = new PriorityQueue<ListNode, int>();

        foreach(var list in lists){
            queue.Enqueue(list, list.val);
        }

        ListNode root = null;
        ListNode prev = null;
        while (queue.Count > 0){
            var node = queue.Dequeue();
            if (node.next is not null)
                queue.Enqueue(node.next, node.next.val);
            
            if (root is null){
                root = node;
            }

            if (prev is not null){
                prev.next = node;
            }

            prev = node;
        }

        return root;
    }
}
