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
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Rol>  Rols { get; set; }
    }
}
