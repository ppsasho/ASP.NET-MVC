using Models;
using Models.Enums;

namespace Video_Rental.Storage
{
    public static class StaticDb
    {
        public static List<User> Users { get; set; } = new List<User>()
         {
             new("Sasho", "Popovski", "ppsasho", "ppsasho1234", "ppsasho@mail.com", 19)
         };
        public static List<Movie> Movies { get; set; } = new List<Movie>()
        {
            new("Spider-Man 3", Genre.Action, DateTime.Now, AgeRestriction.PG13, 6, Language.English, TimeSpan.FromHours(2))
        };
    }
}
