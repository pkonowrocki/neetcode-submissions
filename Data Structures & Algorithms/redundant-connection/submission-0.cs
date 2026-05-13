public class Solution {
    int[] parent;

    public int[] FindRedundantConnection(int[][] edges) {
        parent = new int[edges.Length+1];
        for(int i = 0; i< parent.Length; i++)
            parent[i] = i;

        foreach (var edge in edges){
            int u = edge[0];
            int v = edge[1];

            if (!Union(u, v)){
                return edge;
            }
        }

        return new int[0];
    }

    private int Find(int x){
        if (parent[x] == x)
            return x;
        return parent[x] = Find(parent[x]);
    }

    private bool Union(int x, int y){
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX == rootY)
            return false;
        
        parent[rootY] = rootX;
        return true;
    }
}
