public class Solution {
    public bool IsSubsequence(string s, string t) {
        int sLength = s.Length;
        int tLength = t.Length;
        
        int sPointer =0, tPointer = 0;
        while(sPointer < sLength && tPointer < tLength){
            if(s[sPointer] == t[tPointer])
                sPointer++;
            tPointer++;
        }
        
        return sPointer == s.Length;
    }
}