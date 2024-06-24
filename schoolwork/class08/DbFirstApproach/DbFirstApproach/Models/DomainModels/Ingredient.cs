using System;
using System.Collections.Generic;

namespace DbFirstApproach.Models.DomainModels
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            PizzaIngredients = new HashSet<PizzaIngredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<PizzaIngredient> PizzaIngredients { get; set; }
    }
}
