namespace Storage.Interfaces
{
    public interface IStorage<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void DeleteById(int id);
    }
}
