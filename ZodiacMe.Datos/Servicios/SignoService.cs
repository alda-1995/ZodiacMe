using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZodiacMe.BD;
using ZodiacMe.BD.Modelos;
using ZodiacMe.BD.ViewModels;
using ZodiacMe.Datos.Interfaces;

namespace ZodiacMe.Datos.Servicios
{
    public class SignoService : ISigno
    {
        private readonly BdContext _bdContext;

        public SignoService(BdContext bdContext)
        {
            _bdContext = bdContext;
        }

        public async Task<bool> ActualizarSigno(SignoEditViewModel signo)
        {
            try
            {
                var dateSetNewInicio = new DateTime(1990, signo.FechaInicio.Month, signo.FechaInicio.Day);
                var dateSetNewFin = new DateTime(1990, signo.FechaFin.Month, signo.FechaFin.Day);
                var signoUpdate = await _bdContext.Signos.FirstOrDefaultAsync(s => s.SignoId == signo.SignoId);
                if (signoUpdate == null)
                    return false;
                signoUpdate.Nombre = signo.Nombre;
                signoUpdate.Descripcion = signo.Descripcion;
                signoUpdate.FechaInicio = dateSetNewInicio;
                signoUpdate.FechaFin = dateSetNewFin;
                await _bdContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Guid?> ConsultaSignoNacimiento(DateTime fechaNacimiento)
        {
            try
            {
                var signoId = await _bdContext.Signos
                    .FirstOrDefaultAsync(s =>
                    fechaNacimiento >= s.FechaInicio &&
                    fechaNacimiento <= s.FechaFin);
                return signoId?.SignoId;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CrearSigno(SignoViewModel signo, string pathFile)
        {
            try
            {
                var dateSetNewInicio = new DateTime(1990, signo.FechaInicio.Month, signo.FechaInicio.Day);
                var dateSetNewFin = new DateTime(1990,signo.FechaFin.Month, signo.FechaFin.Day);
                var signoCrear = new Signo()
                {
                    SignoId = Guid.NewGuid(),
                    Nombre = signo.Nombre,
                    Descripcion = signo.Descripcion,
                    FechaInicio = dateSetNewInicio,
                    FechaFin = dateSetNewFin,
                    PathImagen = pathFile,
                    UsuarioId = signo.usuarioId
                };
                await _bdContext.Signos.AddAsync(signoCrear);
                await _bdContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<ListaSignosViewModel>> ObtenerSignos()
        {
            var listSignos = await _bdContext.Signos.ToListAsync();
            return listSignos.Select(s => new ListaSignosViewModel
            {
                Nombre = s.Nombre,
                PathImagen = s.PathImagen,
                SignoId = s.SignoId,
                FechaInicio = s.FechaInicio,
                FechaFin = s.FechaFin
            });
        }

        public async Task<SignoEditViewModel?> ObtieneSigno(Guid idSigno)
        {
            try
            {
                var signoFind = await _bdContext.Signos.Where(s => s.SignoId == idSigno).SingleOrDefaultAsync();
                if(signoFind != null)
                {
                    return new SignoEditViewModel
                    {
                        SignoId = signoFind.SignoId,
                        Nombre = signoFind.Nombre,
                        Descripcion = signoFind.Descripcion,
                        FechaInicio = signoFind.FechaInicio,
                        FechaFin = signoFind.FechaFin,
                        PathImagen = signoFind.PathImagen
                    };
                }
                return null;
            }
            catch
            {
                return null; 
            }
        }
    }
}
