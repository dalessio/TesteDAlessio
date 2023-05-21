using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDAlessio.Domain.Entities;
using TesteDAlessio.Domain.Repository;
using TesteDAlessio.Infrastructure.DBContext;

namespace TesteDAlessio.Infrastructure.Repository
{
    public class CargoRepository : RepositoryBase<Cargo>, ICargoRepository
    {
        public CargoRepository(TesteDAlessioDbContext context) : base(context)
        {
        }
    }
}
