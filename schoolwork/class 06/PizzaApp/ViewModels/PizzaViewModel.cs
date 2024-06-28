using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(51)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string? Description { get; set; }
        [Required]
        [Url]
        [DisplayName("Image link")]
        public string ImageUrl { get; set; }
        public string PizzaType { get; set; }
        [Required]
        public int PizzaTypeValue { get; set; }
    }
}
