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

            if(this.Usuarios != null)
                if (!this.Usuarios.Any())
                {
                    this.Usuarios.Add(new Usuario { Login="admin", Senha="1234", Ativo=true, DataCriacao=DateTime.Now });
                    this.SaveChanges();
                }
        }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }

}
