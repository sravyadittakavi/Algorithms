using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueMorseCodeWords
{
    class UniqueMorseCodeWords
    {
        static void Main(string[] args)
        {
            string[] words = new string[] { "gin", "zen", "gig", "msg" };
            Console.WriteLine(UniqueMorseRepresentations(words));
            Console.ReadLine();
        }
        public static int UniqueMorseRepresentations(string[] words)
        {
            string[] morseCodes = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.",
                "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", 
                "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            List<string> transformations = new List<string>();
            foreach(var word in words)
            {
                string transformation = string.Empty;
                foreach(var character in word)
                {
                    int diff = character - 'a';
                    transformation += morseCodes[diff];
                }
                if (!transformations.Contains(transformation))
                {
                    transformations.Add(transformation);
                }
            }
            return transformations.Count;
        }
    }
}
