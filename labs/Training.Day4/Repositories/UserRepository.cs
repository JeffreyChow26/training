using System.Collections.Generic;
using Training.Day4.Data;
using Training.Day4.Models;

namespace Training.Day4.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public IEnumerable<User> All()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new System.NotImplementedException();
        }

        public User Find(int key)
        {
            throw new System.NotImplementedException();
        }

        public User FindBy<K>(string column, K key)
        {
            throw new System.NotImplementedException();
        }

        public User Load(int key)
        {
            throw new System.NotImplementedException();
        }

        public void Store(User value)
        {
            throw new System.NotImplementedException();
        }
    }
}
