using DomainModels;

namespace DataAccess
{
    public static class StaticDb
    {
        public static Restaurant Restaurant = new Restaurant()
        {
            Id = 1,
            Menu = new List<MenuItem>
            {
                new MenuItem
                {
                    Id = 1,
                    Name = "10ka",
                    Description = "10 kebapi",
                    Price = 160
                }
            }
        };
    }
}
