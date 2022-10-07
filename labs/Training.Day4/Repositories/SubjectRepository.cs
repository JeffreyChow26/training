using System.Collections.Generic;
using Training.Day4.Data;
using Training.Day4.Models;

namespace Training.Day4.Repositories
{
    public class SubjectRepository : IRepository<Subject>
    {
        public IEnumerable<Subject> All()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new System.NotImplementedException();
        }

        public Subject Find(int key)
        {
            throw new System.NotImplementedException();
        }

        public Subject FindBy<K>(string column, K key)
        {
            throw new System.NotImplementedException();
        }

        public Subject Load(int key)
        {
            throw new System.NotImplementedException();
        }

        public void Store(Subject value)
        {
            throw new System.NotImplementedException();
        }
    }
}
