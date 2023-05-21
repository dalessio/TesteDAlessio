using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TesteDAlessio.Infrastructure.DBContext
{
    public class TesteDAlessioDbContextFactory : IDesignTimeDbContextFactory<TesteDAlessioDbContext>
{
        public TesteDAlessioDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TesteDAlessioDbContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TesteDAlessio");

            return new TesteDAlessioDbContext(optionsBuilder.Options);
        }
}}
