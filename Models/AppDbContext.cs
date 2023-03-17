using Microsoft.EntityFrameworkCore;

namespace Money_Tracker.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) { }

        public DbSet<Transaccion> Transacciones { get; set;}
        public DbSet<Categoria> Categorias { get; set;}
    }
}
