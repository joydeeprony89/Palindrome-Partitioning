using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindrome_Partitioning
{
  class Program
  {
    static void Main(string[] args)
    {
      string s = "aabaa";
      Solution sol = new Solution();
      var answer = sol.Partition(s);
      foreach (var a in answer)
        Console.WriteLine(string.Join(",", a));
    }
  }

  public class Solution
  {
    public IList<IList<string>> Partition(string s)
    {
      var res = new List<IList<string>>();
      Dfs(0, new List<string>());

      void Dfs(int start, List<string> temp)
      {
        if (start >= s.Length)
        {
          res.Add(new List<string>(temp));
          return;
        }

        for (int end = start; end < s.Length; end++)
        {
          if (IsPalindrom(start, end))
          {
            temp.Add(s.Substring(start, end - start + 1));
            Dfs(end + 1, temp);
            temp.RemoveAt(temp.Count - 1);
          }
        }

      }

      bool IsPalindrom(int start, int end)
      {
        while (start < end)
        {
          if (s[start++] != s[end--]) return false;
        }
        return true;
      }
      return res;
    }
  }
}
