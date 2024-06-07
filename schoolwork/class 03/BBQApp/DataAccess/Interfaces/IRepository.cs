namespace DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetByID(int id);
        void Save (T entity);
        void Update (T entity);
        void Delete (T entity);
        void DeleteById(int id);
    }
}
