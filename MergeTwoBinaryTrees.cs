using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Solution
    {
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 != default(TreeNode))
            {
                t1.val += t2?.val ?? default(int);
                if (t2?.left != default(TreeNode))
                    t1.left = MergeTrees(t1.left, t2.left);
                if (t2?.right != default(TreeNode))
                    t1.right = MergeTrees(t1.right, t2.right);
            }
            if (t1 == default(TreeNode))
                return t2;
            return t1;
        }
    }
}
