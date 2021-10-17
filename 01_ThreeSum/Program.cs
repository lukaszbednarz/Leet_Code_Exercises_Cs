using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ThreeSum
{
    class Program
    {
        public class Solution
        {
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                var ans = new List<IList<int>>();
                
                var l = nums.Length;

                if (l < 3) return ans;

                var store = new Dictionary<int, HashSet<SortedSet<int>>>();

                var triples = new HashSet<SortedSet<int>>();

                Array.Sort(nums);


                int i = 0;


                while (i < l -2 )
                {
                    var a = nums[i];
                    var j = i + 1;
                    
                    while  (j < l - 1)
                    {
                        var b = nums[j];
                        var ab = a + b;
                        var k = j + 1;

                        while (k < l && nums[k] < -ab)
                        {

                            k++;
                        }


                        if (k < l && ab + nums[k] == 0)
                        {
                            ans.Add(new List<int>() { a, b, nums[k] });

                        }

                        while (j < l - 1 && nums[j] == b) 
                        {
                            j++;
                        }

                        
                    }

                    while (i < l - 2 && nums[i] == a)
                    {
                        i++;
                    }

                }

                return ans;
            }
        }
        static void Main(string[] args)
        {
            var nums = new int[] { -1, 0, 1, 2, -1, -4 };

            var solution = new Solution();

            var ans = solution.ThreeSum(nums);

            foreach(var set in ans)
            {
                Console.WriteLine(string.Format("{0}{1}{2}", set[0], set[1], set[2]));
            }


        }
    }
}
