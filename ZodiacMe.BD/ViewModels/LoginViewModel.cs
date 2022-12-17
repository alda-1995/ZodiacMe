using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZodiacMe.BD.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El correo es requerido")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El formato del correo es incorrecto")]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password, ErrorMessage = "La contraseña es incorrecta")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}
