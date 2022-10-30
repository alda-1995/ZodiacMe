﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZodiacMe.BD.Modelos
{
    public class Signo
    {
        public Signo()
        {
            SignoId = Guid.NewGuid();
        }
        public Guid SignoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}
