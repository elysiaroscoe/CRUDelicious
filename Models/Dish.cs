using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;


namespace CRUDelicious.Models
{
    public class Dish
    {
        //Key is primary key aka id used to identify
        [Key]
        public int DishId { get; set; }
        [Display(Name = "Dish Name: ")]
        [Required(ErrorMessage = "Please enter the dish's name")]
        public string Name { get; set; }
        [Display(Name = "Chef's Name: ")]
        [Required(ErrorMessage = "Please enter the chef's name")]
        public string Chef { get; set; }
        [Display(Name = "Tastiness: ")]
        [Required]
        [Range(1,5, ErrorMessage = "Please enter a number 1-5")]
        public int Tastiness { get; set; }
        [Display(Name = "Calories: ")]
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Please enter calories greater than 0")]
        public int Calories { get; set; }
        [Display(Name = "Description: ")]
        [Required(ErrorMessage = "Please enter a description of the dish")]
        public string Description { get; set; }
    
        // We can provide some hardcoded default values like so:
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        [NotMapped]
        public List<Dish> AllDishes { get; set; }
    }
}