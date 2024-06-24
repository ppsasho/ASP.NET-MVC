using System;
using System.Collections.Generic;

namespace DbFirstApproach.Models.DomainModels
{
    public partial class PizzaIngredient
    {
        public PizzaIngredient()
        {
            Toppings = new HashSet<Topping>();
        }

        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }
        public bool Mandatory { get; set; }

        public virtual Ingredient Ingredient { get; set; } = null!;
        public virtual Pizza Pizza { get; set; } = null!;
        public virtual ICollection<Topping> Toppings { get; set; }
    }
}
