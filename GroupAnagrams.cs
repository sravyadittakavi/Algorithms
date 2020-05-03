public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        IList<IList<string>> returnStrings = new List<List<string>>();
          if (strs.Length == 0) return returnStrings;
        Dictionary<String, List<string>> ans = new Dictionary<String, List<string>>();
        int[] count = new int[26];
        foreach (String s in strs) {
            for (int i = 0; i < 26; i++) count[i] = 0;
            foreach(char c in s.ToCharArray()) count[c - 'a']++;

            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < 26; i++) {
                sb.Append('#');
                sb.Append(count[i]);
            }
            String key = sb.ToString();
            if (!ans.ContainsKey(key)) {
                ans.Add(key, new List<string>());
            }
            ans[key].Add(s);
        }
        
        foreach(var l in ans){
            if(l.Value.Count != 0){
                returnStrings.Add(l.Value);
            }
        }
return returnStrings;
    }
}