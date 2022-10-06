using System;

namespace Training.Day1.Library
{
    public class Employee
    {
        public string Name { get; set; }
    }

    public abstract class Animal
    {
        public virtual int Health { get; } = 10;

        public abstract void Attack();
    }

    public class Dog : Animal
    {
        public string Breed { get; set; }
        public override int Health => 12;

        public override void Attack()
        {
            Console.WriteLine($"{Breed} attacked");
        }

        public static Dog FromConsole()
        {
            Console.WriteLine("Dog");
            Console.WriteLine("------");
            Console.Write("Breed: ");

            string breed = Console.ReadLine();

            return new Dog()
            {
                Breed = breed
            };
        }
    }

    public static class DogExtensions
    {
        public static void Bark(this Dog dog)
        {
            Console.WriteLine($"{dog.Breed} barked");
        }
    }
} 