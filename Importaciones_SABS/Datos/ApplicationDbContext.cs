using Importaciones_SABS.Models;
using Microsoft.EntityFrameworkCore;

namespace Importaciones_SABS.Datos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Usuarios>Usuarios { get; set; }
        public DbSet<Rol>Roles { get; set; }

        public DbSet<Clientes>Clientes { get; set; }

        public DbSet<Proveedores>Proveedores { get; set; }

        public DbSet<Productos>Productos { get; set; }
        public DbSet<Categoria>Categoria { get; set; }


    }
}
