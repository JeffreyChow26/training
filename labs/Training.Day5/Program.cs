using System;
using System.Collections.Generic;

namespace Training.Day5
{
    // Correctness
    // Simplicity
    // Efficiency
    // Testability
    // Maintainance

    public struct User
    {
        public int Id;
        public string FirstName;
        public string LastName;
    }

    public interface IUserRepository
    {
        User? GetById(int id);
        User? GetByEmail(string email);
        void Create(in User user);
    }

    public class UserRepository : IUserRepository
    {
        public User? GetById(int id)
        {
            return null;
        }

        public User? GetByEmail(string email)
        {
            return null;
        }

        public void Create(in User user)
        {

        }
    }

    public class UserService
    {
        public readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public void Authenticate(string email, string password)
        {

        }

        public void Register(in User user)
        {

        }
    }
    
    public class Employee
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    public static class HelperEmployee
    {
        public static void PrintEmployeeNames(this List<Employee> employees)
        {
            foreach (Employee employee in employees)
                Console.WriteLine($"{employee.Name} {employee.Age}");
        }
    }

    public class Program
    {
        public static void Main()
        {

        }
    }
}
