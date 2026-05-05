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
    public List<List<int>> LevelOrder(TreeNode root) {
        var result = new List<List<int>>();
        if (root is null) return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0){
            var subList = new List<int>();
            int levelCount = queue.Count;
            
            for (int i = 0; i < levelCount; i++){
                var node = queue.Dequeue();
                subList.Add(node.val);
                if (node.left is not null)
                    queue.Enqueue(node.left);

                if (node.right is not null)
                    queue.Enqueue(node.right);
            }

            result.Add(subList);
        }

        return result;
    }
}
