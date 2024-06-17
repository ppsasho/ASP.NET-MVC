using Models;

namespace Storage.Interfaces
{
    public interface IDataSet<T> where T : Base
    {
        void Add(T item);
        void Update(T item);
        List<T> GetAll();
    }
}
