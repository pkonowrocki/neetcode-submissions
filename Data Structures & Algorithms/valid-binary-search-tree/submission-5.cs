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
    public bool IsValidBST(TreeNode root) {
        (bool result, int _, int _) = IsValidBSTWithBounds(root);
        
        return result;
    }

    private (bool result, int min, int max) IsValidBSTWithBounds(TreeNode root){
        int min = root.val;
        int max = root.val;
        bool result = true;
        if (root.left is null && root.right is null) return (true, min, max);
        if (root.left is not null){
            (bool isSubtreeValid, int subMin, int subMax) = IsValidBSTWithBounds(root.left);
            if (!isSubtreeValid) result = false;
            if (subMax >= root.val) result = false;
            min = Math.Min(min, subMin);
            max = Math.Max(max, subMax);
        }
        if (root.right is not null){
            (bool isSubtreeValid, int subMin, int subMax) = IsValidBSTWithBounds(root.right);
            if (!isSubtreeValid) result = false;
            if (subMin <= root.val) result = false;
            min = Math.Min(min, subMin);
            max = Math.Max(max, subMax);
        }

        return (result , min, max);
    }
}
