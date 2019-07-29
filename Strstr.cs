using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strstr
{
    class Strstr
    {
        public static void Main(string[] args){
            Console.WriteLine(StrStr("hello", "ll"));
            Console.ReadKey();
        }

        public int StrStr(string haystack, string needle){
            if(needle.Length == 0){
                return 0;
            }
            for(int j=0;j<haystack.Length;j++){
                int startIndex = j;
                int i=0;
                while(i<needle.Length && j< haystack.Length){
                    if(haystack[j] == needle[i]){
                        i++;
                        j++;
                        if(i==needle.Length){
                            return startIndex;
                        }
                    }
                    else{
                        j=startIndex;
                        break;
                    }
                }
                j=startIndex;
            }
            return -1;
        }
    }
}