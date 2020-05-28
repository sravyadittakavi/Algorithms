public class Solution {
    public bool PossibleBipartition(int N, int[][] dislikes) {
        // Construct a graph using adjacency list with the given dislike pairs
        List<List<int>> adjList = new List<List<int>>();
        for(int i=0;i<N;i++){
            adjList.Add(new List<int>());
        }
        
        int[] groups = new int[N];
        for(int i=0;i<N;i++)
            groups[i] = -1;
        
        for(int i=0; i<dislikes.Length;i++){
            var pair = dislikes[i];
            if(pair != null && pair.Length == 2)
                adjList[pair[0]-1].Add(pair[1]-1);
            if(pair != null && pair.Length == 2)
                adjList[pair[1]-1].Add(pair[0]-1);
        }
        
        // Do a DFS on the graph, and alternatively assign 0 and 1 to the visited nodes
        // Groups[i] == -1 denotes vertex i is not visited
        for(int i=0;i<N;i++){
            if(groups[i] == -1 && !DFS(adjList, groups, i, 0))
                return false;
        }
        
        // Verify that this assignment doesn't conflict anywhere
        // If it doesn't conflict, then bipartition can be done, else no
        return true;
    }
    
    // DFS and check if alternate vertices visited have 0 and 1 group values continuously
    private bool DFS(List<List<int>> adjList, int[] groups, int v, int grpValue){
        if(groups[v] == -1)
            groups[v] = grpValue;
        else
            return groups[v] == grpValue;
        
        foreach(int i in adjList[v]){
            if(!DFS(adjList, groups, i, 1-grpValue)){// 1-grpValue will make 1 to 0 and 0 to 1
                return false;
            }
        }
        return true;
    }
}