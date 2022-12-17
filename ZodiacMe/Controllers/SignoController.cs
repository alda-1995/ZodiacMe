using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZodiacMe.BD.ViewModels;
using ZodiacMe.Datos.Interfaces;
using ZodiacMe.Helpers;

namespace ZodiacMe.Controllers
{
    public class SignoController : Controller
    {
        private readonly ISigno _signo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SignoController(ISigno signo, IWebHostEnvironment hostEnvironment)
        {
            _signo = signo;
            _hostEnvironment = hostEnvironment;
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index()
        {
            var listSignos = await _signo.ObtenerSignos();
            return View(listSignos);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(SignoViewModel signoViewModel)
        {
            if (ModelState.IsValid) {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    var claimUser = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                    var idUser = claimUser?.Value;
                    if (idUser == null)
                        return BadRequest();
                    signoViewModel.usuarioId = Guid.Parse(idUser);
                    //subir imagen, con ayuda de un helper
                    var helperUpload = new UploadFileHelper(_hostEnvironment);
                    var pathFile = await helperUpload.SubirImagen(signoViewModel.ImageFile);
                    if (pathFile == string.Empty)
                        return BadRequest();
                    var crearSigno = await _signo.CrearSigno(signoViewModel, pathFile);
                    if(crearSigno)
                        return RedirectToAction("Index", "Admin");
                }
            }
            ModelState.AddModelError("", "Error al guardar los datos.");
            return View(signoViewModel);
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<IActionResult> Actualizar(string id)
        {
            var signo = await _signo.ObtieneSigno(Guid.Parse(id));
            return View(signo);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(SignoEditViewModel signoEditViewModel)
        {
            if (ModelState.IsValid)
            {
                var actualizarSigno = await _signo.ActualizarSigno(signoEditViewModel);
                if (actualizarSigno)
                {
                    return RedirectToAction("Index", "Signo");
                }
            }
            ModelState.AddModelError("", "Verifica tus datos.");
            return View(signoEditViewModel);
        }

        public IActionResult Consultar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Consultar(SignoConsultaViewModel signoConsultaViewModel)
        {
            if (ModelState.IsValid)
            {
                var fechaSigno = new DateTime(1990, signoConsultaViewModel.Mes, signoConsultaViewModel.Dia);
                var signoId = await _signo.ConsultaSignoNacimiento(fechaSigno);
                if (signoId != Guid.Empty && signoId != null)
                {
                    return RedirectToAction("Index", "Signo");
                }
            }
            ModelState.AddModelError("", "No se encontraron resultados.");
            return View(signoConsultaViewModel);
        }
    }
}
