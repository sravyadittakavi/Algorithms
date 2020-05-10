public class Solution {
    public int FindJudge(int N, int[][] trust) {
         if(trust.Length < N-1)
            return -1;
        int[] trustors = new int[N+1];
        int[] trustees = new int[N+1];
        for(int i=0;i<trust.Length;i++){
            trustors[trust[i][0]]++;
            trustees[trust[i][1]]++;
        }
        
        for(int i=1;i<=N;i++){
            if(trustees[i] == N-1 && trustors[i] == 0)
                return i;
        }
        return -1;
    }
}