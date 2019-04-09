using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindromicString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "forgeeksskeegfor";
            int length = LongestPalSubstr(input);
            Console.WriteLine("Length of longest palindromic substring is: " + length);
            Console.ReadKey();
        }


        // This function prints the longest palindrome substring 
        // of str[]. 
        // It also returns the length of the longest palindrome 
        static int LongestPalSubstr(string str)
        {
            int n = str.Length; // get length of input string 

            // table[i][j] will be false if substring str[i..j] 
            // is not palindrome. 
            // Else table[i][j] will be true 
            bool[,] table = new bool[16,16];    

            // All substrings of length 1 are palindromes 
            int maxLength = 1;
            for (int i = 0; i < n; ++i)
            {
                table[i, i] = true;
            }
  
            // check for sub-string of length 2. 
            int start = 0; 
            for (int i = 0; i<n-1; ++i) 
            { 
                if (str[i] == str[i + 1]) 
                { 
                    table[i,i + 1] = true; 
                    start = i; 
                    maxLength = 2; 
                }
            } 
  
            // Check for lengths greater than 2. k is length 
            // of substring 
            for (int k = 3; k <= n; ++k) 
            { 
                // Fix the starting index 
                for (int i = 0; i<n-k+1 ; ++i) 
                { 
                    // Get the ending index of substring from 
                    // starting index i and length k 
                    int j = i + k - 1; 
  
                    // checking for sub-string from ith index to 
                    // jth index iff str[i+1] to str[j-1] is a 
                    // palindrome 
                    if (table[i + 1,j - 1] && str[i] == str[j]) 
                    { 
                        table[i,j] = true; 
  
                        if (k > maxLength) 
                        { 
                            start = i; 
                            maxLength = k; 
                        } 
                    } 
                } 
            } 
  
            Console.WriteLine("Longest palindrome substring is: ");
            Console.WriteLine(str.Substring(start, maxLength)); 
  
            return maxLength; // return length of LPS 
        }
    }
}
