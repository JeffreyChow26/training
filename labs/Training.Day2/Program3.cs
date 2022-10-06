using System;
using System.Collections.Generic;
using System.Linq;

namespace Training.Day2
{
    public class Program3
    {
        public static void Main()
        {
            var list = new List<int>() { 2, 3, 4, 5, 6, 7 };
            foreach (var x in list.Where(x => x > 5).Select(x => x * 5))
                Console.WriteLine(x);
            Console.WriteLine();
            foreach (var x in list)
                Console.WriteLine(x);
            Console.Read();
        }
    }
}
