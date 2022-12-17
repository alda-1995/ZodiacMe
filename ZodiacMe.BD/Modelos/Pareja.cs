using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZodiacMe.BD.Modelos
{
    public class Pareja
    {
        public Pareja()
        {
            ParejaId = Guid.NewGuid();
        }
        public Guid ParejaId { get; set; }
        public string Descripcion { get; set; }
        public Guid SignoId { get; set; }
        public Signo Signo { get; set; }
    }
}
