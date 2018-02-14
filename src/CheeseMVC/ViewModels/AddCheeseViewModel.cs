using CheeseMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide description for the cheese")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Rating is in range 1-5")]
        public int Rating { get; set; }

        public Cheese CreateCheese(AddCheeseViewModel addCheeseViewModel)
        {
            Cheese newCheese = new Cheese
            {
                Name = addCheeseViewModel.Name,
                Description = addCheeseViewModel.Description,
                Rating = addCheeseViewModel.Rating
            };


            return newCheese;
        }
    }
}
