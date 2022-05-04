using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindrome_Partitioning
{
  class Program
  {
    static void Main(string[] args)
    {
      string s = "aab";
      Program p = new Program();
      p.Partition(s);
    }

    public IList<IList<string>> Partition(string s)
    {
      var result = new List<IList<string>>();

      Backtracking(s, result, new List<string>(), 0);
      return result;
    }

    private void Backtracking(string s, List<IList<string>> result, List<string> temp, int start)
    {
      if (start == s.Length)
      {
        result.Add(new List<string>(temp));
      }
      else
      {
        for (int i = start; i < s.Length; i++)
        {
          if (IsPalindrom(s, start, i))
          {
            temp.Add(s.Substring(start, i + 1));
            Backtracking(s, result, temp, i + 1);
            temp.RemoveAt(temp.Count - 1);
          }
        }
      }
    }

    private bool IsPalindrom(string s, int i , int j)
    {
      while(i < j)
        if (s[i++] != s[j--]) return false;
      return true;
    }
  }
}
