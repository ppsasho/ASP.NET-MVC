namespace DomainModels
{
    public class Restaurant : BaseClass
    {
        public List<MenuItem>? Menu { get; set; }
        public string? Name { get; set; }
        
    }
}
