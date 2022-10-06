using System;
using System.Collections.Generic;

namespace Training.Day2
{
    public class Program1
    {
        public static void Main1()
        {
            List<int> inputs = new List<int>() { 2, 3, 5, 6, 7, 9, 10 };
            Console.WriteLine(Sum(inputs, evenOnly: true));
            Console.ReadLine();
        }
        
        public abstract class Summation
        {
            protected virtual bool Check(int x) => true;

            public int Execute(List<int> inputs)
            {
                int sum = 0;
                foreach (int x in inputs)
                {
                    if (Check(x))
                        sum += x;
                }
                return sum;
            }
        }

        public class EvenSummation : Summation
        {
            protected override bool Check(int x)
            {
                return x % 2 == 0;
            }
        }

        public abstract class Predicate
        {
            public abstract bool Check(int x);
        }

        public static int SumO(List<int> inputs, Predicate pred)
        {
            int sum = 0;
            foreach (int x in inputs)
            {
                if (pred.Check(x))
                    sum += x;
            }
            return sum;
        }
        
        public static int SumF(List<int> inputs, Func<int, bool> pred)
        {
            int sum = 0;
            foreach (int x in inputs)
            {
                if (pred(x))
                    sum += x;
            }
            return sum;
        }

        public static int Sum(List<int> inputs, bool evenOnly)
        {
            int sum = 0;
            foreach (int x in inputs)
            {
                if (!evenOnly || x % 2 == 0)
                    sum += x;
            }
            return sum;
        }
    }
}
