using System;
using System.Collections.Generic;

namespace DbFirstApproach.Models.DomainModels
{
    public partial class Topping
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public int IngredientId { get; set; }
        public decimal PricePerItem { get; set; }

        public virtual PizzaIngredient Ingredient { get; set; } = null!;
        public virtual OrderDetail OrderItem { get; set; } = null!;
    }
}
