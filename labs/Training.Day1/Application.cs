using System;
using System.Linq;
using Training.Day1.Library;

namespace Training.Day1
{
    public class Application
    {
        public void Run()
        {
            foreach (CategoryBoundary boundary in CategoryBoundary.GetBonudaries())
                 Console.WriteLine($"Category: {boundary.Category} has the range {boundary.Low} - {boundary.High}");

            while (true)
            {
                int value = int.Parse(Console.ReadLine());
                Category cat = CategoryBoundary.GetBonudaries().FirstOrDefault(x => value >= x.Low && value <= x.High).Category;

                Console.WriteLine(cat);
            }
        }
    }
}
