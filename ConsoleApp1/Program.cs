using System;
using System.Linq;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            var wcNoJj = new[] {9, 8, 7, 6, 5, 4, 3, 3, 2, 2, 2, 1, 1, 1, 1};
            Array.Sort(wcNoJj);
            foreach (var jj in wcNoJj) {
                Console.Write($"{jj}, ");
            }

            Console.WriteLine("");
            var wcsb=wcNoJj.GroupBy(i => i).ToArray();
            var group1 = wcsb[0];
            foreach (var wc in group1.ToArray()) {
                Console.WriteLine(wc);
            }
        }
    }
}