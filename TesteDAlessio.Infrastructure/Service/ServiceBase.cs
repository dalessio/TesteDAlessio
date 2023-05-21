using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDAlessio.Domain.Entities;
using TesteDAlessio.Domain.Repository;
using TesteDAlessio.Domain.Service;

namespace TesteDAlessio.Infrastructure.Service
{
    public class ServiceBase<TRepository> where TRepository : IRepositoryBase
                                                
    {
    }
}
