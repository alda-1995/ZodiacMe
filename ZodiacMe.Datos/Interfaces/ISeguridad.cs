using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZodiacMe.BD.Modelos;
using ZodiacMe.BD.ViewModels;

namespace ZodiacMe.Datos.Interfaces
{
    public interface ISeguridad
    {
        Task<Usuario> ValidateUser(string email, string password);
        Task<Usuario> GetUserByEmail(string email);
        Task<Usuario> Registro(string password, string email);

    }
}
