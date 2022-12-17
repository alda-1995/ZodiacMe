using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZodiacMe.BD.Modelos;

namespace ZodiacMe.BD
{
    public class BdContext : DbContext
    {
        public BdContext()
        {

        }

        public BdContext(DbContextOptions<BdContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializerRol(modelBuilder).Seed();
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Signo> Signos { get; set; }
        public virtual DbSet<Pareja> Parejas { get; set; }
    }
}
