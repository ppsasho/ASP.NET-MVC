using DomainModels;
using ViewModels;

namespace Mappers
{
    public static class PizzaMappers
    {
        public static PizzaViewModel ToModel(this Pizza pizza)
        {
            var model = new PizzaViewModel()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Description = pizza.Description,
                ImageUrl = pizza.ImageUrl,
                PizzaType = pizza.PizzaType.ToString()
            };
            return model;
        }
    }
}
