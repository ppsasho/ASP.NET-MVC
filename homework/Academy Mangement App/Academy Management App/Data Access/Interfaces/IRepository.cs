using Domain_Models;

namespace Data_Access.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
            public List<T> GetAll();
            public T GetById(int id);
            public void Add(T entity);
            public void Update(T entity);
            public void Delete(T entity);
            public void DeleteById(int id);
    }
}
