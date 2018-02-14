using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public CheeseType Type { get; set; }

        public List<SelectListItem> CheeseTypes { get; set; }

        public AddCheeseViewModel()
        {
            
            CheeseTypes = new List<SelectListItem>();
            //TODO <option value = "0">Hard</option>
            //Implement looop through listItems
            CheeseTypes.Add(new SelectListItem {
                Value = ((int) CheeseType.Hard).ToString(),
                Text = CheeseType.Hard.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = CheeseType.Soft.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Fake).ToString(),
                Text = CheeseType.Fake.ToString()
            });
        }

        public Cheese CreateCheese(AddCheeseViewModel addCheeseViewModel)
        {
            Cheese newCheese = new Cheese
            {
                Name = addCheeseViewModel.Name,
                Description = addCheeseViewModel.Description,
                Rating = addCheeseViewModel.Rating,
                Type = addCheeseViewModel.Type
            };


            return newCheese;
        }
    }
}
