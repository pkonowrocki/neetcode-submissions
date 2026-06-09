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

public class Codec {

    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        List<string> nodes = new List<string>();
        Dfs(root, nodes);
        return string.Join(',', nodes);
    }

    private void Dfs(TreeNode root, List<string> nodes){
        if(root is null){
            nodes.Add("#");
            return;
        }

        nodes.Add(root.val.ToString());
        Dfs(root.left, nodes);
        Dfs(root.right, nodes);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        var queue = new Queue<string>(data.Split(','));
        return DDfs(queue);
    }

    private TreeNode DDfs(Queue<string> data){
        var val = data.Dequeue();
        if (val=="#"){
            return null;
        }

        var root = new TreeNode();
        root.val = Int32.Parse(val);
        root.left = DDfs(data);
        root.right = DDfs(data);
        return root;
    }
}
