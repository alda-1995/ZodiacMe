using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZodiacMe.BD.Modelos;

namespace ZodiacMe.BD
{
    public class DbInitializer
    {
        public void Initialize(BdContext _bdContext)
        {
            ArgumentNullException.ThrowIfNull(_bdContext, nameof(_bdContext));
            _bdContext.Database.EnsureCreated();
            if (_bdContext.Usuarios.Any()) return;
            CrearPasswordHash("admin123", out byte[] passwordHash, out byte[] passwordSalt);
            var admin = new Usuario()
            {
                Email = "admin@gmail.com",
                RolId = 1,
                Password_hash = passwordHash,
                Password_salt = passwordSalt,
            };
            _bdContext.Usuarios.Add(admin);
            try
            {
                _bdContext.SaveChanges();
            }
            catch
            {

                throw;
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
