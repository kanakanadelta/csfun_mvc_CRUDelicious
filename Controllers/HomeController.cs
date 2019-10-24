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
            return View();
        }
    
    }
}