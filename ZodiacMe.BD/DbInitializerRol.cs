using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZodiacMe.BD.Modelos;

namespace ZodiacMe.BD
{
    public class DbInitializerRol
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializerRol(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            modelBuilder.Entity<Rol>().HasData(
                   new Rol() { Nombre = "Administrador", RolId = 1 },
                   new Rol() { Nombre = "Personal", RolId = 2 }
            );
        }

    }
}
