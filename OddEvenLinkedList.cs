public class Solution {
    public ListNode OddEvenList(ListNode head) {
        if(head == null)
            return null;
        ListNode odd = head, even = head.next, evenHead = even;
        while(even != null && even.next != null ){
            odd.next = even.next;
            odd = even.next;
            even.next = odd.next;
            even = odd.next;
        }
        odd.next = evenHead;
        return head;
    }
}