using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Collections.Generic;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        // Dependency Injection
        private CruddyContext dbContext;
        // here we can "inject" our context service into the constructor
        public HomeController(CruddyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> AllDishes = dbContext.Dishes.ToList();
            ViewBag.Dishes = AllDishes;
            return View();
        }

        [HttpGet("new")]
        public IActionResult New(Dish dish)
        {
            return View(dish);
        }

        [HttpPost("create")]
        public IActionResult Create(Dish dish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }

        [HttpGet("{dishId}")]
        public IActionResult Show(int dishId)
        {
            Dish dishRow = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

            return View(dishRow);
        }

        [HttpGet("{dishId}/edit")]
        public IActionResult Edit(int dishId)
        {
            Dish dishRow = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

            return View(dishRow);
        }

        // [HttpGet("{dishId}/update")]
        // public IActionResult UpdateDish(
        //     int dishId, 
        //     string chefName,
        //     string dishName,
        //     int calories,
        //     int tastiness,
        //     string description
        //     )
        // {
        //     Dish dishRow = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

        //     dishRow.ChefName = chefName;
        //     dishRow.DishName = dishName;
        //     dishRow.Calories = calories;
        //     dishRow.Tastiness = tastiness;
        //     dishRow.Description = description;
        //     dishRow.UpdatedAt = System.DateTime.Now;

        //     dbContext.SaveChanges();
        //     return RedirectToAction("Show", new{id=dishRow.DishId});

        // }

        [HttpGet("{dishId}/update")]
        public IActionResult UpdateDish(Dish updatedDish, int dishId)
        {
            Dish dishRow = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

            dishRow.ChefName = updatedDish.ChefName;
            dishRow.DishName = updatedDish.DishName;
            dishRow.Calories = updatedDish.Calories;
            dishRow.Tastiness = updatedDish.Tastiness;
            dishRow.Description = updatedDish.Description;
            // dishRow = updatedDish;
            // dishRow.DishId = dishId;
            dishRow.UpdatedAt = System.DateTime.Now;

            dbContext.SaveChanges();
            return RedirectToAction("Show", new{id=dishRow.DishId});

        }

        [HttpGet("{dishId}/delete")]
        public IActionResult DeleteDish(int dishId)
        {
            Dish dishRow = dbContext.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

            dbContext.Dishes.Remove(dishRow);

            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}