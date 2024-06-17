using Models.Enums;

namespace Models
{
    public class Movie : Base
    {
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public Language Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Length { get; set; }
        public AgeRestriction AgeRestriction { get; set; }
        public int Quantity { get; set; }

        public Movie(string title, Genre genre, DateTime releaseDate, AgeRestriction ageRestriction, int quantity, Language language, TimeSpan length)
        {
            Title = title;
            Genre = genre;
            ReleaseDate = releaseDate;
            AgeRestriction = ageRestriction;
            Quantity = quantity;
            Language = language;
            Length = length;
        }
        public bool IsAvailable()
        {
            return Quantity > 0;
        }
        public void Rent(User user)
        {

        }
    }
}
