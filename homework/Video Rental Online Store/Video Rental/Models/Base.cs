namespace Models
{ 
    public abstract class Base
    {
        public int Id { get; set; }
        public Base(int id) 
        {
            Id = id;
        }

    }
}
