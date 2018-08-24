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
            string[] path = new string[] { "root/a 1.txt(abcd) 2.txt(efgh)", "root/c 3.txt(abcd)", "root/c/d 4.txt(efgh)", "root 4.txt(efgh)" };


            try
            {
                var ret = new Solution().FindDuplicate(path);
                //test
            }
            catch(Exception e)
            {
                e.ToString();
            }
        }
    }
    public class Solution
    {
        public IList<IList<string>> FindDuplicate(string[] paths)
        {
            Dictionary<String, IList<String>> dictionary = new Dictionary<string, IList<string>>();
            foreach(var path in paths)
            {
                var files = path.Split(' ');
                var directory = files[0];
                foreach (var file in files.Skip(1))
                {
                    var st = file.IndexOf('(') + 1;
                    var length = file.IndexOf(')') - st;
                    var contents = file.Substring(st, length);
                    var fileName = file.Substring(0, st - 1);
                    if (!dictionary.ContainsKey(contents))
                        dictionary.Add(contents, new List<string>());
                    dictionary[contents].Add($"{directory}/{fileName}");
                }
            }
            IList<IList<String>> ret = new List<IList<String>>();
            foreach (var key in dictionary.Keys)
            {
                var list = dictionary[key];
                if (list.Count() >= 2)
                    ret.Add(list);
            }
            return ret;
        }
    }

    public class Solution2
    {
        public int NumIslands(char[,] grid)
        {
            
            var length1 = grid.GetLength(0);
            var length2 = grid.GetLength(1);
            bool[,] visited = new bool[length1, length2];
            int[] NX = new int[] { 0, 0, -1, 1 };
            int[] NY = new int[] { -1, 1, 0, 0 };
            int cnt = 0;
            Queue<Pair<int>> q = new Queue<Pair<int>>();
            for (int i = 0; i < length1; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    if (!visited[i, j] && grid[i, j] == '1')
                    {
                        visited[i, j] = true;
                        q.Enqueue(new Pair<int>(i, j));
                        while (q.Any())
                        {
                            var data = q.Dequeue();
                            for (int k = 0; k < 4; k++)
                            {
                                var nX = data.First + NX[k];
                                var nY = data.Second + NY[k];
                                if (nX < 0 || nY < 0 || nX >= length1 || nY >= length2)
                                    continue;
                                if (!visited[nX, nY] && grid[nX, nY] == '1')
                                {
                                    q.Enqueue(new Pair<int>(nX, nY));
                                    visited[nX, nY] = true;
                                }
                            }
                        }
                        cnt++;
                    }
                }
            }
            return cnt;
        }
        class Pair<T>
        {
            public T First;
            public T Second;
            public Pair(T first, T second)
            {
                this.First = first;
                this.Second = second;
            }
        }
    }
}
