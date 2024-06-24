using System;
using System.Collections.Generic;

namespace DbFirstApproach.Models.DomainModels
{
    public partial class Pizza
    {
        public Pizza()
        {
            Menus = new HashSet<Menu>();
            PizzaIngredients = new HashSet<PizzaIngredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<PizzaIngredient> PizzaIngredients { get; set; }
    }
}
