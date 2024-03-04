using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZodiacMe.BD.ViewModels;

namespace ZodiacMe.Datos.Interfaces
{
    public interface IPareja
    {
        Task<bool> AgregarParejaSigno(ParejaViewModel parejaViewModel)  ;
    }
}
