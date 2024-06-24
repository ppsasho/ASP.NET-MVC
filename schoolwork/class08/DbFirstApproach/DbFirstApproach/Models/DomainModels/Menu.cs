using System;
using System.Collections.Generic;

namespace DbFirstApproach.Models.DomainModels
{
    public partial class Menu
    {
        public Menu()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int SizeId { get; set; }
        public decimal? Price { get; set; }

        public virtual Pizza Pizza { get; set; } = null!;
        public virtual Size Size { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
