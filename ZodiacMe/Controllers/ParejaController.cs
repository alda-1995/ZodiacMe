using Microsoft.AspNetCore.Mvc;

namespace ZodiacMe.Controllers
{
    public class ParejaController : Controller
    {
        public async Task<IActionResult> Crear(string ?id)
        {
            return View();
        }
    }
}
