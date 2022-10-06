using System;
using System.Collections.Generic;
using System.Linq;

namespace Training.Day3
{
    public class Employee : IEquatable<Employee>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime HireDate { get; set; }

        public bool Equals(Employee other)
        {
            return Name == other.Name && Age == other.Age && HireDate == other.HireDate;
        }
    }

    public class EmployeeComparer : IComparer<Employee>
    {
        public enum CompareBy
        {
            Age,
            HireDate,
            Name
        }

        private readonly CompareBy _compareBy;

        public EmployeeComparer(CompareBy compareBy) =>
            _compareBy = compareBy;

        public int Compare(Employee x, Employee y)
        {
            switch (_compareBy)
            {
                case CompareBy.Age:
                    return x.Age.CompareTo(y.Age);
                case CompareBy.HireDate:
                    return x.HireDate.CompareTo(y.HireDate);
                case CompareBy.Name:
                    return x.Name.CompareTo(y.Name);
                default:
                    throw new InvalidOperationException();
            }
        }
    }

    public class EmployeEqualityComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Name.GetHashCode();
        }
    }

    public class Order : IComparable<Order>
    {
        public int Id { get; set; }
        public string SubmittedBy { get; set; }
        public DateTime SubmittedDate { get; set; }

        public int CompareTo(Order other)
        {
            return SubmittedDate.CompareTo(other.SubmittedDate);
        }
    }

    public class Program1
    {
        public static void Main0()
        {
            var orders = new SortedSet<Order>()
            {
                new Order { Id = 5, SubmittedBy = "James", SubmittedDate = new DateTime(2022, 5, 30) },
                new Order { Id = 6, SubmittedBy = "John", SubmittedDate = new DateTime(2022, 5, 6) },
                new Order { Id = 8, SubmittedBy = "Jane", SubmittedDate = new DateTime(2022, 5, 24) },
                new Order { Id = 1, SubmittedBy = "John", SubmittedDate = new DateTime(2022, 5, 20) }
            };

            foreach (Order order in orders)
                Console.WriteLine($"{order.Id} {order.SubmittedBy} {order.SubmittedDate}");
            Console.ReadLine();
        }

        public static void Main1()
        {
            var employees = new List<Employee>()
            {
                new Employee { Name = "James", Age = 25, HireDate = new DateTime(2022, 5, 1) },
                new Employee { Name = "Jane", Age = 21, HireDate = new DateTime(2022, 5, 3) },
                new Employee { Name = "Frank", Age = 40, HireDate = new DateTime(2022, 5, 5) },
                new Employee { Name = "Frank", Age = 40, HireDate = new DateTime(2023, 5, 5) }
            };

            Output(employees.Where(x => x.HireDate.Year > 2005).ToList());
            Output(employees.Any(x => x.HireDate.Year == 2015));
            Output(employees.All(x => x.Age >= 18));
            Output(employees.Aggregate((x, y) => x.HireDate < y.HireDate ? x : y));
            Output(employees.OrderBy(x => x.Name).ToList().First());
            Output(employees.OrderBy(x => x.HireDate).ToList().First());
            Output(employees.Distinct(new EmployeEqualityComparer()).ToList());
            Output(employees.FirstOrDefault(x => x.Age > 50));
            Output(employees.Single(x => x.Name == "Jane"));

            Console.WriteLine(employees[1].Equals(employees[2]));
            Console.ReadLine();
        }

        private static void Output(object x)
        {
            Console.WriteLine(x);
            Console.WriteLine();
        }

        private static void Output(Employee x, bool newline = true)
        {
            if (x == null)
                Console.WriteLine("null null null");
            else
                Console.WriteLine($"{x.Name} {x.Age} {x.HireDate}");

            if (newline)
                Console.WriteLine();
        }

        private static void Output(IEnumerable<Employee> x)
        {
            foreach (var emp in x)
                Output(emp, false);
            Console.WriteLine();
        }
    }
}
