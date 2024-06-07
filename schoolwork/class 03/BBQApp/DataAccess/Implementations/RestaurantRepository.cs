using DataAccess.Interfaces;
using DomainModels;

namespace DataAccess.Implementations
{
    public class RestaurantRepository : IRepository<Restaurant>
    {
        public void Delete(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Restaurant> GetAll()
        {
            return new List<Restaurant> { StaticDb.Restaurant };
        }

        public Restaurant GetByID(int id)
        {
            return StaticDb.Restaurant;
        }

        public void Save(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Restaurant entity)
        {
            throw new NotImplementedException();
        }
    }
}
