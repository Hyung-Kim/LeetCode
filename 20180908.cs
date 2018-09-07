using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var s = new Solution();
            Debug.WriteLine(s.GetHint("1122", "2211"));*/

        }
    }
 
  
      public class TreeNode {
          public int val;
          public TreeNode left;
          public TreeNode right;
          public TreeNode(int x) { val = x; }
      }
 
    public class Solution1
    {
        int kth = 0;
        public int KthSmallest(TreeNode root, int k)
        {
            if (root == default(TreeNode))
                return Int32.MinValue;
            var ret = KthSmallest(root.left, k);
            if (kth == k)
                return ret;
            if (++kth == k)
                return root.val;
            return KthSmallest(root.right, k);
        }
    }
    
    public class Solution2
    {
        public string GetHint(string secret, string guess)
        {
            var dict1 = new int[10];
            var dict2 = new int[10];
            int strike = 0;
            int ball = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                    strike++;
                else
                {
                    dict1[Int32.Parse(secret[i].ToString())]++;
                    dict2[Int32.Parse(guess[i].ToString())]++;
                }
            }
            for (int i = 0; i < 10; i++)
                ball += Math.Min(dict1[i], dict2[i]);
            return $"{strike}A{ball}B";
        }
    }
}
