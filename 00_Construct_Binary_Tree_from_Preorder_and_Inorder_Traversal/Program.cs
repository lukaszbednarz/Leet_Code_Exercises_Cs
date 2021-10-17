using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal
{
    class Program
    {
          //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }

            
        }

        public class Solution
        {
            Dictionary<int, int> inorderIndexMap = new Dictionary<int, int>();
            int preorderIndex = 0;
            
            public TreeNode BuildTree(int[] preorder, int[] inorder)
            {
                

                for (int i = 0; i < inorder.Length; i++)
                {
                    inorderIndexMap[inorder[i]] = i;
                }

                
                
                return _BuildTree(preorder, 0, inorder.Length - 1);
            }

            public TreeNode _BuildTree(int[] preorder, int left, int right)
            {
                if (left > right) return null;


                var rootValue = preorder[preorderIndex];
                var root = new TreeNode(rootValue);
                preorderIndex++;

                root.left = _BuildTree(preorder, left, inorderIndexMap[rootValue] - 1);
                root.right = _BuildTree(preorder, inorderIndexMap[rootValue] + 1, right);

                return root;
            }
        }
        static void Main(string[] args)
        {

            int[] preorder = new int[] { 3, 9, 20, 15, 7 };
            int[] inorder = new int[] { 9, 3, 15, 20, 7 };

            var solution = new Solution();

            var ans = solution.BuildTree(preorder, inorder);

            Console.WriteLine(ans);


        }
    }
}
