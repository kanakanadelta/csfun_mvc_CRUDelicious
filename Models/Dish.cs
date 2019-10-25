using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [Display(Name = "Chef's Name")]
        public string ChefName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [Display(Name = "Name of Dish")]
        public string DishName { get; set; }

        [Display(Name = "# of Calories")]
        public int Calories { get; set; }

        [Display(Name = "Tastiness")]
        public int Tastiness { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}