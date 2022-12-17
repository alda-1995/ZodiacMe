using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZodiacMe.BD.ViewModels
{
    public class SignoConsultaViewModel
    {
        [Required(ErrorMessage = "El mes es requerido")]
        [Display(Name = "Mes")]
        public int Mes { get; set; }
        [Required(ErrorMessage = "El dia es requerido")]
        [Display(Name = "Dia")]
        public int Dia { get; set; }
    }
}
