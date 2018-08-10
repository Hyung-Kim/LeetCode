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
        public static Hashtable table = new Hashtable();
        static Solution()
        {
            table.Add('(', ')');
            table.Add('{', '}');
            table.Add('[', ']');
        }

        public bool IsValid(string s)
        {
            try
            {
                Stack<Char> stack = new Stack<Char>();
                foreach (var bracket in s)
                {
                    if (table.ContainsKey(bracket))
                        stack.Push(bracket);
                    else
                    {
                        var tBracket = stack.Pop();
                        if ((Char)table[tBracket] != bracket)
                            throw new Exception();
                    }
                }
                if (stack.Any())
                    throw new Exception();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
