namespace Models
{
    public class Rental : Base
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }

        public Rental(int userId, int movieId)
        {
            UserId = userId;
            MovieId = movieId;
        }

        public DateTime? ReturnedOn { get; set; }
        
        public void Return()
        {

        }
    }
}

