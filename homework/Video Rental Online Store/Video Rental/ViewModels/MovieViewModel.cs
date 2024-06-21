using Models.Enums;

namespace ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public Language Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Length { get; set; }
        public AgeRestriction AgeRestriction { get; set; }
        public int Quantity { get; set; }

        public bool IsAvailable()
        {
            return Quantity > 0;
        }
    }
}
