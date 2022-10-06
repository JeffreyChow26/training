using System;
using System.Collections.Generic;

namespace Training.Day1.Library
{
    public struct CategoryBoundary
    {
        public Category Category;
        public int Low;
        public int High;

        public CategoryBoundary(Category category, int low, int high) =>
            (Category, Low, High) = (category, low, high);

        public static IEnumerable<CategoryBoundary> GetBonudaries()
        {
            int[] values = (int[])Enum.GetValues(typeof(Category));
            int low = 0;
            int high;

            for (int i = 1; i < values.Length; i++)
            {
                high = values[i];

                yield return new CategoryBoundary((Category)values[i], low, high);

                low = high + 1;
            }
        }
    }
}
