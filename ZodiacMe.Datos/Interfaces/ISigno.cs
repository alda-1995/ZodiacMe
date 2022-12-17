using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZodiacMe.BD.Modelos;
using ZodiacMe.BD.ViewModels;

namespace ZodiacMe.Datos.Interfaces
{
    public interface ISigno
    {
        public Task<IEnumerable<ListaSignosViewModel>> ObtenerSignos();
        public Task<bool> CrearSigno(SignoViewModel signo, string pathFile);
        public Task<SignoEditViewModel?> ObtieneSigno(Guid idSigno);
        public Task<bool> ActualizarSigno(SignoEditViewModel signo);
        public Task<Guid?> ConsultaSignoNacimiento(DateTime fechaNacimiento);
    }
}
