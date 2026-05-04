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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode current = head;
        for (int i = 0; i<n; i++){
            current = current.next;
        }
        ListNode nthCurrent = head;
        ListNode shadow = null;
        while (current != null){
            current = current.next;
            shadow = nthCurrent;
            nthCurrent = nthCurrent.next;
        }

        if (shadow == null){
            return nthCurrent.next;
        }

        shadow.next = nthCurrent.next;
        return head;
    }
}
