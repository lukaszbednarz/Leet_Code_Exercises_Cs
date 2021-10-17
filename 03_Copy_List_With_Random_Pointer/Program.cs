using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Copy_List_With_Random_Pointer
{
    class Program
    {
        // Definition for a Node.
        // Definition for a Node.
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }

        public class Solution
        {
            static public Node BuildList(int[][] l)
            {
                Node ret = null;
                Dictionary<int, Node> store = new Dictionary<int, Node>();


                for (int i = l.Length - 1; i >= 0;  i--)
                {
                    Node tmp;
                    var val = l[i][0];
                    var random = l[i][1];

                    
                    if (store.ContainsKey(i))
                    {
                        tmp = store[i];
                    }
                    else
                    {
                        tmp = new Node(val);
                        store[i] = tmp;
                    }

                    tmp.next = ret;
                    ret = tmp;

                    if (random == -1) continue;

                    if (store.ContainsKey(random)) {
                        tmp = store[random];
                    }
                    else
                    {
                        tmp = new Node(l[random][0]);
                        store[random] = tmp;

                    }

                    ret.random = tmp;
                }

                return ret;

            }

            static public List<List<int>> ToArray(Node l)
            {
                var ans = new List<List<int>>();

                int pos = 0;

                while (l != null)
                {
                    ans.Add(new List<int>() { l.val, l.next?.val ?? -1, l.random?.val ?? -1 });

                    pos++;
                    l = l.next;
                }

                return ans;

            }

            static public List<List<int>> ToDictionary(Node l)
            {
                var dict = new Dictionary<Node, int>();

                var ans = new List<List<int>>();

                var head = l;

                int pos = 0;

                while (l != null)
                {
                    dict[l] = pos;

                    pos++;
                    l = l.next;
                }

                l = head;

                while (l != null)
                {
                    ans.Add(new List<int>() {l.val, dict[l] });

                    pos++;
                    l = l.next;
                }

                return ans;

            }


            static public void PrintList(Node l)
            {

                foreach (var n in ToArray(l))
                {
                    Console.WriteLine(string.Format("val: {0}, next: {1}, random: {2}", n[0], n[1], n[2]));
                }

            }

            public Node CopyRandomList(Node head)
            {
                Dictionary<Node, Node> store = new Dictionary<Node, Node>();

                if (head == null) return null;

                Node ret = new Node(head.val);
                store[head] = ret;
                var curr = head;
                Node prev = null;

                while  (curr != null)
                {
                    Node tmp;
                    var val = curr.val;
                    var random = curr.random;

                    if (store.ContainsKey(curr))
                    {
                        tmp = store[curr];
                    }
                    else
                    {
                        tmp = new Node(val);
                        store[curr] = tmp;
                    }
                    if (prev != null) {
                        prev.next = tmp;
                    }

                    prev = tmp;

                    curr = curr.next;

                    if (random == null) continue;

                    if (store.ContainsKey(random))
                    {
                        tmp = store[random];
                    }
                    else
                    {
                        tmp = new Node(random.val);
                        store[random] = tmp;
                    }

                    prev.random = tmp;
                }

                return ret;

            }
        }
        static void Main(string[] args)
        {


            int[][] n1 = new int[5][];
            n1[0] = new int[] { 7, -1 };
            n1[1] = new int[] { 13, 0 };
            n1[2] = new int[] { 11, 4 };
            n1[3] = new int[] { 10, 2 };
            n1[4] = new int[] { 1, 0 };

            int[][] n2 = new int[3][];
            n2[0] = new int[] { 3, -1 };
            n2[1] = new int[] { 3, 0 };
            n2[2] = new int[] { 3, -1 };

            var l1 = Solution.BuildList(n2);

            Solution.PrintList(l1);

            var sol = new Solution();

            var ans = sol.CopyRandomList(l1);

            var n = Solution.ToArray(ans);

            Solution.PrintList(ans);


        }
    }
}

