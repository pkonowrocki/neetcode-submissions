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
    public int max = int.MinValue;
    public int MaxPathSum(TreeNode root) {
        TestForMax(root);
        return max;
    }

    private int TestForMax(TreeNode root) {
        if (root is null) return 0;
        
        int leftMax = Math.Max(0, TestForMax(root?.left));
        int rightMax = Math.Max(0, TestForMax(root?.right));

        
        
        max = Math.Max(max, leftMax + rightMax + root.val);
        
        return root.val + Math.Max(leftMax, rightMax);
    }
}
