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
                var signoUpdate = await _bdContext.Signos.FirstOrDefaultAsync(s => s.SignoId == signo.SignoId);
                if (signoUpdate == null)
                    return false;
                signoUpdate.Nombre = signo.Nombre;
                signoUpdate.Descripcion = signo.Descripcion;
                signoUpdate.FechaInicio = signo.FechaInicio;
                signoUpdate.FechaFin = signo.FechaFin;
                await _bdContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Guid?> ConsultaSignoNacimiento(SignoConsultaViewModel signo)
        {
            try
            {
                var signoId = await _bdContext.Signos
                    .FirstOrDefaultAsync(s =>
                    s.FechaInicio >= signo.FechaNacimiento &&
                    s.FechaFin <= signo.FechaNacimiento);
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
                var signoCrear = new Signo()
                {
                    SignoId = Guid.NewGuid(),
                    Nombre = signo.Nombre,
                    Descripcion = signo.Descripcion,
                    FechaInicio = signo.FechaInicio,
                    FechaFin = signo.FechaFin,
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
