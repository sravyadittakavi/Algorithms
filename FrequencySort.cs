public class Solution {
    public string FrequencySort(string s) {
        Dictionary<char, int> freq = new Dictionary<char, int>();
        
        foreach(char c in s){
           if(freq.ContainsKey(c))
               freq[c] = freq[c]+1;
            else
                freq.Add(c,1);
        }
        
        freq = freq.OrderByDescending(x=>x.Value).ToDictionary(x=>x.Key, x=>x.Value);
        
        StringBuilder sb = new StringBuilder();
        foreach(var pair in freq){
            for(int i=0;i<pair.Value;i++){
                sb.Append(pair.Key);
            }
        }
        
        return sb.ToString();
    }
}