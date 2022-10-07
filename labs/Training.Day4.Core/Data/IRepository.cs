using System.Collections.Generic;

namespace Training.Day4.Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> All();
        T Find(int key);
        T FindBy<K>(string column, K key);
        void Store(T value);
        T Load(int key);
        void Delete(int key);
    }
}
