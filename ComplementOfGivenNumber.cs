public class Solution {
    public int FindComplement(int num) {
        // Complement is achieved by xor with all 1's of same length
        // as that of input
        // Length is achieved with below formula
        int n = (int)(Math.Log(num)/Math.Log(2))+1;
        // Get number with all 1's
        int bitmask = (1 << n) -1;
        // Perform XOR
        return bitmask ^ num;
    }
}