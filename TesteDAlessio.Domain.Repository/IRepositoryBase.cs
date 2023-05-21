using System.Linq.Expressions;

namespace TesteDAlessio.Domain.Repository
{
    public interface IRepositoryBase<TEntity> : IRepositoryBase
    {
        Task<TEntity> GetById(int id);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);

        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate);
    }

    public interface IRepositoryBase { }
}