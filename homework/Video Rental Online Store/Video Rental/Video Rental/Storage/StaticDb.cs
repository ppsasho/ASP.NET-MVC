using Models;
using Models.Enums;
using ViewModels;

namespace Video_Rental.Storage
{
    public static class StaticDb
    {
        public static List<UserViewModel> Users { get; set; } = new List<UserViewModel>()
         {
             new("Sasho", "Popovski", 19, "ppsasho", "ppsasho@mail.com", "ppsasho1234")
         };
        public static List<Movie> Movies { get; set; } = new List<Movie>()
        {
            new("Spider-Man 3", Genre.Action, DateTime.Now, AgeRestriction.PG13, 6, Language.English, TimeSpan.FromHours(2), 1)
        };
    }
}
