using System;
using System.Collections.Generic;

namespace DbFirstApproach.Models.DomainModels
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            Toppings = new HashSet<Topping>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuId { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }

        public virtual Menu Menu { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
        public virtual ICollection<Topping> Toppings { get; set; }
    }
}
