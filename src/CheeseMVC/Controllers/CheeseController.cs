﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private CheeseDbContext context;

        public CheeseController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Cheese> cheeses = context.Cheeses.ToList();

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

                context.Cheeses.Add(addCheeseViewModel.CreateCheese(addCheeseViewModel));
                context.SaveChanges();
                return Redirect("/Cheese");
            }
            //TODO Create method in AddCheeseViewModel that return an object of new cheese
            //and add this object to CheeseData CheeseData.Add(newCheese);
            return View(addCheeseViewModel);
         
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = context.Cheeses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId);
                context.Cheeses.Remove(theCheese);
            }

            context.SaveChanges();

            return Redirect("/");
        }

        public IActionResult Edit(int cheeseId)
        {
            Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId);
            ViewBag.edit = theCheese; 
            return View();
        }   

        [HttpPost]
        public IActionResult Edit(AddEditCheeseViewModel addEditCheeseViewModel)
        {
  
            Cheese cheese = context.Cheeses.Single(c => c.ID == addEditCheeseViewModel.CheeseId);

            cheese.Name = addEditCheeseViewModel.Name;
            cheese.Description = addEditCheeseViewModel.Description;
            cheese.ID = addEditCheeseViewModel.CheeseId;
            context.SaveChanges();
            return Redirect("/");
        }

    }
}
