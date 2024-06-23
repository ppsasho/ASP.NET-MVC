namespace ViewModels
{
    public class RentalViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public DateTime? RentedOn { get; set; }
        public DateTime? ReturnedOn { get; set; }
    }
}
