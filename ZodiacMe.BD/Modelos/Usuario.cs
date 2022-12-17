using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZodiacMe.BD.Modelos
{
    public class Usuario
    {
        public Usuario()
        {
            UsuarioId = Guid.NewGuid();
        }
        [Key]
        public Guid UsuarioId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public byte[] Password_hash { get; set; }
        [Required]
        public byte[] Password_salt { get; set; }
        public byte RolId { get; set; }
        public Rol Rol { get; set; }

        public ICollection<Signo> Signos { get; set; }
    }
}
