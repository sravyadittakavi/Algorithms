using System;

/// <summary>
/// Delete node in linkedlist given access to only the node to be deleted.
/// </summary>
public class Solution
{
    public void DeleteNode(ListNode node)
    {
        node.val = node.next.val;
        node.next = node.next.next;
    }
}
