using Microsoft.EntityFrameworkCore;
using ListaDeContactos.Api.Models;

namespace ListaDeContactos.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contacto> Contactos { get; set; }
    }
}