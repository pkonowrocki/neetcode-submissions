/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        TreeNode current = root;
        while ((p.val <= current.val && q.val <= current.val) || 
            (p.val >= current.val && q.val >= current.val)){

                if (current == p || current == q) return current;
                
                
                if (p.val < current.val && q.val < current.val)
                    current = current.left;
                
                if (p.val > current.val && q.val > current.val)
                    current = current.right;

            }
        return current;
    }
}
