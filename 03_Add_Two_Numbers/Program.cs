using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Add_Two_Numbers
{
    class Program
    {

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
             this.val = val;
             this.next = next;
            }

        }

        public class Solution
        {
            static public ListNode BuildList(int[] l)
            {
                ListNode ret = null;

                for (int i = l.Length -1; i >= 0; i--)
                {
                    ret = new ListNode(l[i], ret);
                }

                return ret;
            }

            static public List<int> ToArray(ListNode l)
            {
                var ans = new List<int>();

                while (l != null)
                {
                    ans.Add(l.val);

                    l = l.next;
                }

                return ans;
            }

            static public void PrintList(ListNode l)
            {
                
                foreach(var n in ToArray(l))
                {
                    Console.WriteLine(n);
                }

            }

            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                
                var ans = new ListNode(0);
                var current = ans;

                while(current != null)
                {
                    var carry = current.val;

                    carry += (l1?.val ?? 0) + (l2?.val ?? 0);

                    current.val = carry % 10;
                    carry /= 10;

                    l1 = l1?.next;
                    l2 = l2?.next;

                    if (l1 != null || l2 != null || carry > 0) {

                        current.next = new ListNode(carry);
                        current = current.next;

                    }
                    else
                    {
                        current = null;
                    }

                }
                
                return ans;
            }
        }
        static void Main(string[] args)
        {

            int[] n1 = new int[]{ 9, 9, 9, 9, 9, 9, 9 };
            int[] n2 = new int[]{ 9, 9, 9, 9 };

            var l1 = Solution.BuildList(n1);
            var l2 = Solution.BuildList(n2);

            var sol = new Solution();

            var ans = sol.AddTwoNumbers(l1, l2);

            var n = Solution.ToArray(ans);

            Solution.PrintList(ans);
            

        }
    }
}
