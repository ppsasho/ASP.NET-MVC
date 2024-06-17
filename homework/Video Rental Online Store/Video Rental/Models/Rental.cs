namespace Models
{
    public class Rental : Base
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public DateTime? RentedOn { get; set; }

        public Rental(int userId, int movieId)
        {
            UserId = userId;
            MovieId = movieId;
            RentedOn = DateTime.UtcNow;
        }

        public DateTime? ReturnedOn { get; set; }
        
        public void Return()
        {

        }
    }
}

