using DataAccess.Implementation;
using DataAccess.Interface;
using DomainModels;
using Mappers;
using Services.Interface;
using ViewModels;

namespace Services.Implementation
{
    public class PizzaService : IPizzaService
    {
        private IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public List<PizzaViewModel> GetAll()
        {
            var pizzas = _pizzaRepository.GetAll();
            return pizzas.Select(x => x.ToModel()).ToList();
        }

        public PizzaViewModel GetDetails(int id)
        {
            var pizza = _pizzaRepository.GetById(id);
            return pizza.ToModel();
        }

        public void Create(PizzaViewModel pizza)
        {
            if (_pizzaRepository.GetAll().Any(x => x.Name.ToLower() == pizza.Name.ToLower()))
            {
                throw new Exception($"Pizza with the name [{pizza.Name}] already exists");
            };

            var newPizza = new Pizza()
            {
                Name = pizza.Name,
                Description = pizza.Description,
                ImageUrl = pizza.ImageUrl
            };
            _pizzaRepository.Add(newPizza);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PizzaViewModel> SearchByName(string name)
        {
            var pizzas = _pizzaRepository.SearchByName(name);
            return pizzas.Select(x => x.ToModel()).ToList();
        }

        public void Update(PizzaViewModel pizza)
        {
            throw new NotImplementedException();
        }
    }
}