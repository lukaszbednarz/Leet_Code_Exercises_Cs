using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Longest_Substring_Without_Repeating_Characters
{
    class Program
    {
        public class Solution
        {
            public int LengthOfLongestSubstring(string s)
            {
                if (s.Length == 0)
                {
                    return 0;
                }

                int maxLen = 0;
                int j = -1;
                Dictionary<char, int> dict = new Dictionary<char, int>();
                                
                for(int i = 0; i < s.Length; i++)
                {
                    var c = s[i];
                    if (dict.ContainsKey(c) && dict[c] > j)
                    {
                        j = dict[c];
                    }
                    dict[c] = i; 

                    if(i - j > maxLen)
                    {
                        maxLen = i - j;
                    }

                }


                return maxLen;
            }
        }
        static void Main(string[] args)
        {
            var solution = new Solution();
            string s = "abba";
            var rsp = solution.LengthOfLongestSubstring(s);

            Console.WriteLine(String.Format("Longest Substring: {0}", rsp));
        }
    }
}
