using Microsoft.AspNetCore.Mvc;

namespace ZodiacMe.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
