using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Cheese> cheeses = CheeseData.GetAll();

            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if(ModelState.IsValid)
            {

                CheeseData.Add(addCheeseViewModel.CreateCheese(addCheeseViewModel));

                return Redirect("/Cheese");
            }
            //TODO Create method in AddCheeseViewModel that return an object of new cheese
            //and add this object to CheeseData CheeseData.Add(newCheese);
            return View(addCheeseViewModel);
         
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }

            return Redirect("/");
        }

        public IActionResult Edit(int cheeseId)
        {
            ViewBag.edit = CheeseData.GetById(cheeseId); 
            return View();
        }   

        [HttpPost]
        public IActionResult Edit(AddEditCheeseViewModel addEditCheeseViewModel)
        {
            var cheese = CheeseData.GetById(addEditCheeseViewModel.CheeseId);

            cheese.Name = addEditCheeseViewModel.Name;
            cheese.Description = addEditCheeseViewModel.Description;
            cheese.CheeseId = addEditCheeseViewModel.CheeseId;
            

            return Redirect("/");
        }

    }
}
