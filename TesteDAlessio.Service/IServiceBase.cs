using TesteDAlessio.Domain.Repository;

namespace TesteDAlessio.Domain.Service
{
    public interface IServiceBase<T> : IServiceBase where T : IRepositoryBase
    {
    }

    public interface IServiceBase
    {
    }

}