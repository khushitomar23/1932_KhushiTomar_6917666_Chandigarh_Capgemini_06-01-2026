using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] words = { "listen", "silent", "hello", "world", "abc", "cba" };
        Dictionary<string, int> map = new Dictionary<string, int>();

        foreach (string w in words)
        {
            char[] ch = w.ToCharArray();
            Array.Sort(ch);
            string key = new string(ch);

            if (!map.ContainsKey(key))
                map[key] = 0;
            map[key]++;
        }

        foreach (string w in words)
        {
            char[] ch = w.ToCharArray();
            Array.Sort(ch);
            if (map[new string(ch)] == 1)
                Console.WriteLine(w);
        }
    }
}
