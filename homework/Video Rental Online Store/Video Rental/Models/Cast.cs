using Models.Enums;

namespace Models
{
    public class Cast : Base
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public Part Part { get; set; }

        public Cast(int movieId, string name, Part part)
        {
            MovieId = movieId;
            Name = name;
            Part = part;
        }

    }
}
