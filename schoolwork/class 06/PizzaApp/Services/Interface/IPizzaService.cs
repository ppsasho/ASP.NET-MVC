using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;

namespace Services.Interface
{
    public interface IPizzaService
    {
        List<PizzaViewModel> GetAll();
        void Create(PizzaViewModel model);
        void Update(PizzaViewModel model);
        void Delete(int id);
        PizzaViewModel GetDetails(int id);
        List<PizzaViewModel> SearchByName(string name);
        List<SelectListItem> GetTypeOptions();
    }
}
