public class Solution {
    public int NumJewelsInStones(string J, string S) {
        int count = 0;
        foreach(char a in S.ToCharArray()){
            if(J.Contains(a.ToString()))
                count++;
        }
        return count;
    }
}