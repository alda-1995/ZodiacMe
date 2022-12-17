using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZodiacMe.BD.ViewModels;
using ZodiacMe.Datos.Interfaces;

namespace ZodiacMe.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISeguridad _seguridad;

        public LoginController(ISeguridad seguridad)
        {
            _seguridad = seguridad;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid) {
                var userFind = await _seguridad.ValidateUser(loginViewModel.Email, loginViewModel.Password);
                if(userFind != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, userFind.UsuarioId.ToString()),
                        new Claim(ClaimTypes.Email, userFind.Email),
                        new Claim(ClaimTypes.Role, userFind.Rol.Nombre)
                    };
                    try
                    {
                        var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return new RedirectResult(url: "/Admin/", permanent: true, preserveMethod: true);
                    }
                    catch
                    {
                        return BadRequest();
                    }
                }
            }
            ModelState.AddModelError("", "La contraseña o usuario son incorrectos.");
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
