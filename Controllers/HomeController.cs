using Microsoft.AspNetCore.Mvc;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    
    }
}