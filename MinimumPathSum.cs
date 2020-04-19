public class Solution {
    public int MinPathSum(int[][] grid) {
        int[][] result = new int[grid.Length][];
        
        for(int i=grid.Length-1;i>=0;i--){
             result[i] = new int[grid[i].Length];
            for(int j=grid[0].Length-1;j>=0;j--){
                if(i==grid.Length -1 && j!= grid[0].Length -1)
                    result[i][j] = grid[i][j]+result[i][j+1];
                else if(j==grid[0].Length-1 && i!=grid.Length -1)
                    result[i][j] = grid[i][j] + result[i+1][j];
                else if(i != grid.Length -1 && j!= grid[0].Length -1)
                    result[i][j] = grid[i][j] + Math.Min(result[i+1][j], result[i][j+1]);
                else
                    result[i][j] = grid[i][j];
            }
        }
        
        return result[0][0];
    }
}