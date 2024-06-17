using DataAccess.Implementation;
using DataAccess.Interface;
using DomainModels;
using Mappers;
using Services.Interface;
using System.Reflection;
using ViewModels;

namespace Services.Implementation
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<Pizza> _pizzaRepository;
        public PizzaService()
        {
            _pizzaRepository = new PizzaRepository();
        }
        public List<PizzaViewModel> GetAll()
        {
            var pizzas = _pizzaRepository.GetAll();
            return pizzas.Select(x => x.ToModel()).ToList();
        }
        public void Create (PizzaViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public PizzaViewModel GetDetails(int id)
        {
            var pizza = _pizzaRepository.GetById(id);
            return pizza.ToModel();
        }

        public PizzaViewModel GetById(int id)
        {
            var pizza = _pizzaRepository.GetById(id);
            return pizza.ToModel();
        }

        public List<PizzaViewModel> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(PizzaViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
