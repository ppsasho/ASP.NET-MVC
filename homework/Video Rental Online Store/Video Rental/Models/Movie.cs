using Models.Enums;

namespace Models
{
    public class Movie : Base
    {
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public string Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Length { get; set; }
        public AgeRestriction AgeRestriction { get; set; }
        public int Quantity { get; set; }

        public Movie(string title, Genre genre, string language, DateTime releaseDate, string length, AgeRestriction ageRestriction, int quantity)
        {
            Title = title;
            Genre = genre;
            Language = language;
            ReleaseDate = releaseDate;
            Length = length;
            AgeRestriction = ageRestriction;
            Quantity = quantity;
        }
        public void Rent(User user)
        {

        }
    }
}
