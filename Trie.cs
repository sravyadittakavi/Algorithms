public class Trie {

    Trie[] children;
    bool isEndOfWord;
    
    /** Initialize your data structure here. */
    public Trie() {
        children = new Trie[26];
        isEndOfWord = false;
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) {
        Trie current = this;
        foreach (var c in word)
        {
            if(current.children[c-'a'] == null)
                current.children[c-'a'] = new Trie();
            current = current.children[c-'a'];
        }
        current.isEndOfWord = true;
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) {
        Trie current = this;
        foreach (var c in word)
        {
            current = current.children[c-'a'];
            if(current == null)
                return false;
        }
        if(current.isEndOfWord)
            return true;
        return false;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) {
         Trie current = this;
        foreach (var c in prefix)
        {
            current = current.children[c-'a'];
            if(current== null)
                return false;
        }
        return true;
    }
}
