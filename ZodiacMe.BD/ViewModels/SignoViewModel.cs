using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZodiacMe.BD.ViewModels
{
    public class SignoViewModel
    {
        public Guid usuarioId { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        [BindProperty]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha inicio")]
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [Display(Name = "Fecha fin")]
        public DateTime FechaFin { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
