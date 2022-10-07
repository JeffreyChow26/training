using System.Collections.Generic;

namespace Training.Day4.Data
{
    public class SqliteRepository<T> : IRepository<T>
    {
        public IEnumerable<T> All()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int key)
        {
            throw new System.NotImplementedException();
        }

        public T Find(int key)
        {
            throw new System.NotImplementedException();
        }

        public T FindBy<K>(string column, K key)
        {
            throw new System.NotImplementedException();
        }

        public T Load(int key)
        {
            throw new System.NotImplementedException();
        }

        public void Store(T value)
        {
            throw new System.NotImplementedException();
        }
    }
}
