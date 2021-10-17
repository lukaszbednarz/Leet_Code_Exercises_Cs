using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Spiral_matrix
{
    class Program
    {
        public class Solution
        {
            public IList<int> SpiralOrder(int[][] matrix)
            {
                var ret = new List<int>();

                int n = matrix.Length;

                if (n == 0) return ret;

                int min_i = 0;
                int max_i = matrix.Length - 1;
                int min_j = 0;
                int max_j = matrix[0].Length - 1;

                while (min_j <= max_j)
                {
                    // top row
                    for (int j = min_j; j <= max_j; j++)
                    {
                        ret.Add(matrix[min_i][j]);
                    }
                    min_i++;

                    if (min_i > max_i) return ret;

                    // right column
                    for (int i = min_i; i <= max_i; i++)
                    {
                        ret.Add(matrix[i][max_j]);
                    }
                    max_j--;

                    if (min_j > max_j) return ret;

                    // bottom row
                    for (int j = max_j; j >= min_j; j--)
                    {
                        ret.Add(matrix[max_i][j]);
                    }
                    max_i--;

                    if (min_i > max_i) return ret;

                    // left column
                    for (int i = max_i; i >= min_i; i--)
                    {
                        ret.Add(matrix[i][min_j]);
                    }
                    min_j++;
                }

                return ret;
            }

        }

        static void Main(string[] args)
        {
            var nums = new int[3][];

            nums[0] = new int[] { 1, 2, 3, 4 };
            nums[1] = new int[] { 5, 6, 7, 8 };
            nums[2] = new int[] { 9, 10, 11, 12};

            var solution = new Solution();

            var ans = solution.SpiralOrder(nums);

            foreach (var set in ans)
            {
                Console.WriteLine(set);
            }

        }
    }
}
