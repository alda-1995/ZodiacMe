using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZodiacMe.BD.Modelos
{
    public class Rol
    {
        public byte RolId { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
