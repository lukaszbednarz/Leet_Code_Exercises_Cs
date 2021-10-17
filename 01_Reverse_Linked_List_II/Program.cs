using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Reverse_Linked_List_II
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

                for (int i = l.Length - 1; i >= 0; i--)
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

                foreach (var n in ToArray(l))
                {
                    Console.WriteLine(n);
                }

            }

            public ListNode ReverseBetween(ListNode head, int left, int right)
            {
                ListNode reversed = null;
                var curr = head;

                ListNode top = null;
                ListNode tail = null;

                Stack<ListNode> stack = new Stack<ListNode>();

                int pos = 1;


                while (curr != null && pos <= right)
                {
                    if (pos < left)
                    {
                        top = curr;
                    }
                    else if (pos == left)
                    {
                        tail = curr;
                        reversed = tail;

                    }
                    else
                    {
                        reversed = new ListNode(curr.val, reversed);
                    }
                    curr = curr.next;
                    pos += 1;
                }

                //rejoin
                if (tail != null)
                {
                    tail.next = curr;
                }

                if (top != null)
                {
                    top.next = reversed;
                }
                else if (reversed != null)
                {
                    head = reversed;
                }



                return head;
            }
        }
        static void Main(string[] args)
        {

            int left = 1;
            int right = 2;

            int[] n1 = new int[] {3, 5 };

            var l1 = Solution.BuildList(n1);

            var sol = new Solution();

            var ans = sol.ReverseBetween(l1, left, right);

            var n = Solution.ToArray(ans);

            Solution.PrintList(ans);


        }
    }
}
