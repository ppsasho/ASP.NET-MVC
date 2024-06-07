namespace DomainModels
{
    public class OrderItem : BaseClass
    {
        public MenuItem? MenuItemId { get; set; }

        public List<OrderItem>? OrderItems { get; set; }
    }
}
