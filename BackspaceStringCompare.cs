public class Solution {
    public bool BackspaceCompare(string S, string T) {
        return Construct(S).Equals(Construct(T));
    }

    public String Construct(string s){
        Stack<char> st = new Stack<char>();
        foreach(char c in s.ToCharArray()){
            if(c!='#'){
                st.Push(c);
            }
            else if(st.Count != 0){
                st.Pop();
            }
        }
        char[] stChar = st.ToArray();
        return new String(stChar);
    }
}