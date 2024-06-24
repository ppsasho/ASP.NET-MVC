using System;
using System.Collections.Generic;

namespace DbFirstApproach.Models.DomainModels
{
    public partial class Size
    {
        public Size()
        {
            Menus = new HashSet<Menu>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
