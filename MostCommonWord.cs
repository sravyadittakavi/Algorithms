using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MostCommonWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";//"a, a, a, a, b,b,b,c, c"
            string[] banned = new string[] { "hit" };
            string mostCommonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most common word: " + mostCommonWord);
            Console.ReadKey();
        }

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            if (!String.IsNullOrEmpty(paragraph))
            {
                List<string> wordsInPara = paragraph.ToLower().Split(' ').ToList();
                int highestCount = 1;
                string mostCommonWord = string.Empty;
                foreach (var word in wordsInPara)
                {
                    int count = 0;
                    string noPunctuationWord = Regex.Replace(word, @"\p{P}*$", string.Empty);
                    if (banned.Contains(noPunctuationWord))
                    {
                        continue;
                    }
                    else
                    {
                        if (wordCount.ContainsKey(noPunctuationWord))
                        {
                            count = wordCount[noPunctuationWord]+1;
                            wordCount[noPunctuationWord] = count;
                        }
                        else
                        {
                            wordCount.Add(noPunctuationWord, 1);
                            count = 1;
                        }
                        if (count >= highestCount)
                        {
                            highestCount = count;
                            mostCommonWord = noPunctuationWord;
                        }
                    }
                }              
              
                return mostCommonWord;
            }
            return string.Empty;
        }
    }
}
