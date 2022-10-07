using System.Collections.Generic;
using Training.Day4.Data;
using Training.Day4.Models;

namespace Training.Day4.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        public IEnumerable<Student> All()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new System.NotImplementedException();
        }

        public Student Find(int key)
        {
            throw new System.NotImplementedException();
        }

        public Student FindBy<K>(string column, K key)
        {
            throw new System.NotImplementedException();
        }

        public Student Load(int key)
        {
            throw new System.NotImplementedException();
        }

        public void Store(Student value)
        {
            throw new System.NotImplementedException();
        }
    }
}
