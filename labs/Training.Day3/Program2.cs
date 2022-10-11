using System;

namespace Training.Day3
{
    public class Program2
    {
        public interface INamedEntity
        {
            string NameId { get; }
        }

        public interface IPopOnlyStack<out T>
        {
            T Pop();
        }

        public interface IPushOnlyStack<in T>
        {
            void Push(T value);
        }

        public interface ICustomStack<T> : IPushOnlyStack<T>, IPopOnlyStack<T>
        {
            int Count();
        }

        public class CustomStack<T> : ICustomStack<T>
        {
            private int _index;
            private readonly T[] _array = new T[10];

            public void Push(T value) => _array[_index++] = value;
            public T Pop() => _array[--_index];
            public int Count() => _index;
        }

        public class CustomStackExtendedOf
        {
            public static void DisplayAllInternsNameAndId(ICustomStack<INamedEntity> stack)
            {
                while (stack.Count() > 0)
                    Console.WriteLine(stack.Pop().NameId);
            }
        }

        public class Jedi : INamedEntity
        {
            private readonly string _name;
            private readonly int _id;

            public string NameId => $"Jedi - {_name}:{_id}";

            public Jedi(string name, int id) =>
                (_name, _id) = (name, id);
        }

        public static void Main()
        {
            var stack = new CustomStack<INamedEntity>();

            stack.Push(new Jedi("Jane", 1));
            stack.Push(new Jedi("John", 4));
            stack.Push(new Jedi("James", 8));

            CustomStackExtendedOf.DisplayAllInternsNameAndId(stack);
            Console.ReadLine();
        }
    }
}
