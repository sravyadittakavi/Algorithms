public class RandomizedSet {
Dictionary<int,int> dict = new Dictionary<int, int>();
    List<int> list = new List<int>();
    Random rand = new Random();
    
    /** Initialize your data structure here. */
    public RandomizedSet() {
        dict = new Dictionary<int,int>();
        list = new List<int>();
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        if(dict.ContainsKey(val)) return false;
        
        dict.Add(val, list.Count);
        list.Add(val);
        return true;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        if(!dict.ContainsKey(val)) return false;
        
         // move the last element to the place idx of the element to delete
        int lastElement = list[list.Count-1];
        int index = dict[val];
        list[index] = lastElement;  
        dict[lastElement] = index;
        
        // delete last element
        list.RemoveAt(list.Count -1);
        dict.Remove(val);
        return true;
    }
    
    /** Get a random element from the set. */
    public int GetRandom() {
       return list[rand.Next(list.Count)];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */