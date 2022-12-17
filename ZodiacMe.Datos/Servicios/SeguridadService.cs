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
    public class SeguridadService : ISeguridad
    {
        private readonly BdContext _bdContext;

        public SeguridadService(BdContext bdContext)
        {
            _bdContext = bdContext;
        }

        public async Task<Usuario> GetUserByEmail(string email)
        {
            var userBd = await _bdContext.Usuarios.Where(s => s.Email == email).Include(u => u.Rol).FirstOrDefaultAsync();
            return userBd;
        }

        public async Task<Usuario> ValidateUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var emailFormat = email.ToLower();
            var usuario = await _bdContext.Usuarios.Include(u => u.Rol).FirstOrDefaultAsync(u => u.Email == emailFormat);
            
            if(usuario == null)
            return null;

            if (!VerificarPasswordHash(password, usuario.Password_hash, usuario.Password_salt))
                return null;

            return usuario;
        }

        public async Task<Usuario> Registro(string password, string email)
        {
            CrearPasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            Usuario usuario = new Usuario
            {
                RolId = 2,
                Email = email,
                Password_hash = passwordHash,
                Password_salt = passwordSalt,
            };

            _bdContext.Usuarios.Add(usuario);
            try
            {
                await _bdContext.SaveChangesAsync();
                return usuario;
            }
            catch
            {
                return null;
            }
        }

        private bool VerificarPasswordHash(string password, byte[] passwordHashAlmacenado, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passwordHashNuevo = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return new ReadOnlySpan<byte>(passwordHashAlmacenado).SequenceEqual(new ReadOnlySpan<byte>(passwordHashNuevo));
            }
        }

        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
