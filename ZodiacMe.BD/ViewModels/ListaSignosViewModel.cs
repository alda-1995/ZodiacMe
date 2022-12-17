﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZodiacMe.BD.ViewModels
{
    public class ListaSignosViewModel
    {
        public Guid SignoId { get; set; }
        public string Nombre { get; set; }
        public string PathImagen { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
