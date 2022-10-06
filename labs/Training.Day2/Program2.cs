using System;
using System.Linq;
using System.Collections.Generic;

namespace Training.Day2
{
    public class Program2
    {
        public static void Main2()
        {
            Queue<int> queue = InputQueue();

            var arr = new int[queue.Count];
            var list = new List<int>(queue.Count);
            var dict = new Dictionary<int, int>(list.Count);

            PopulateCollections(queue, arr, list, dict);
            OutputCollections(arr, list, dict);
        }

        public static Queue<int> InputQueue()
        {
            var queue = new Queue<int>();

            while (true)
            {
                Console.Write("Input: ");
                int value = int.Parse(Console.ReadLine());

                if (value == -1)
                    break;

                queue.Enqueue(value);
            }

            return queue;
        }

        public static void PopulateCollections(Queue<int> inputs, int[] arr, List<int> list, Dictionary<int, int> dict)
        {
            int index = 0, value;

            while (inputs.Count > 0)
            {
                value = inputs.Dequeue();

                arr[index] = value;
                dict.Add(index, value);
                list.Add(value);

                index++;
            }
        }

        public static void OutputCollections(int[] arr, List<int> list, Dictionary<int, int> dict)
        {
            Console.WriteLine("Using Array");
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine($"{i} : {arr[i]}");

            Console.WriteLine("Using List<T>");
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"{i} : {list[i]}");

            Console.WriteLine("Using Dictionary<TKey, TValue>");
            foreach (var kv in dict.OrderBy(kv => kv.Key))
                Console.WriteLine($"{kv.Key} : {kv.Value}");

            Console.ReadLine();
        }
    }
}
