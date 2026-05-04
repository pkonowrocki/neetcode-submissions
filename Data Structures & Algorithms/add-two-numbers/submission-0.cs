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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode result = null;
        ListNode current = null;
        int pass = 0;
        while (l1 != null || l2 != null){

            (ListNode sum, int newPass) = AddTwoDigits(l1, l2, pass); 
            if (current is null){
                current = sum;
                result = sum;
            }
            else{
                current.next = sum;
                current = current.next;
            }
            pass = newPass;
            l1 = l1?.next;
            l2 = l2?.next;
        }

        if (pass > 0){
            current.next = new ListNode(pass);
        }

        return result;
    }

    private (ListNode node, int pass) AddTwoDigits(ListNode l1, ListNode l2, int prevPass){
        int sum = (l1?.val??0) + (l2?.val??0) + prevPass;
        return (new ListNode(sum%10), sum/10);
    }
}
