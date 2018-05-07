using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySorting
{
    class Program
    {
        // Sort list or array by string length
        static void Main(string[] args)
        {
            foreach (string word in sort("longasdad", "short", "pepepepepepepepe", "s", "d"))
            {
                Console.Out.WriteLine(word);
            }
            Console.In.Read();
        }

        static string[] sort(params string[] words)
        {
            return words.OrderBy(r => r.Length).ToArray();
        }
    }
}
