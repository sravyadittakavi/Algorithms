public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        if(ransomNote.Length > magazine.Length)
            return false;
        
        Dictionary<char, int> ransomCounts = ConstructCountsDict(ransomNote);
        Dictionary<char, int> magazineCounts = ConstructCountsDict(magazine);
        
        foreach(var item in ransomCounts.Keys){
            int countInMagazine = magazineCounts.ContainsKey(item)?magazineCounts[item]:0;
            int countInRansom = ransomCounts[item];
            
            if(countInRansom > countInMagazine)
                return false;
        }
        
        return true;
    }
    
    public Dictionary<char, int> ConstructCountsDict(string s){
        Dictionary<char, int> counts = new Dictionary<char, int>();
        foreach(var c in s){
            if(counts.ContainsKey(c))
                counts[c] = counts[c]+1;
            else
                counts.Add(c,1);
        }
        return counts;
    }
}