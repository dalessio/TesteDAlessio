using Microsoft.EntityFrameworkCore;
using TesteDAlessio.Domain.Entities;


namespace TesteDAlessio.Infrastructure.DBContext
{
    public class TesteDAlessioDbContext : DbContext
    {
        public TesteDAlessioDbContext(DbContextOptions<TesteDAlessioDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }

}
