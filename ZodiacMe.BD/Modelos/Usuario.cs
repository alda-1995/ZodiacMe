﻿using System;
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
        public string Correo { get; set; }
        [Required]
        public string Password { get; set; }

        public byte RolId { get; set; }
        public Rol Rol { get; set; }
    }
}
