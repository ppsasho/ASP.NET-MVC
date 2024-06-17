using ViewModels;

namespace Services.Interface
{
    public interface IPizzaService
    {
        List<PizzaViewModel> GetAll();
        PizzaViewModel GetById(int id);
        void Create(PizzaViewModel model);
        void Update(PizzaViewModel model);
        void Delete(int id);
        PizzaViewModel GetDetails(int id);
        List<PizzaViewModel> SearchByName(string name);

    }
}
