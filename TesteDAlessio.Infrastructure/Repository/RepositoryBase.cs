using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TesteDAlessio.Domain.Entities;
using TesteDAlessio.Domain.Repository;
using TesteDAlessio.Domain.Service;
using TesteDAlessio.Infrastructure.DBContext;

namespace TesteDAlessio.Infrastructure.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
                                                                    where TEntity : EntityBase
                                                                    
    {
        public TesteDAlessioDbContext Context { get; set; }

        public RepositoryBase(TesteDAlessioDbContext context)
        {
            Context = context;
        }

        #region Public Methods

        public Task<TEntity> GetById(int id) => Context.Set<TEntity>().FindAsync(id).AsTask();

        public Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate) => Context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        public async Task Add(TEntity entity)
        {
            //await Context.AddAsync(entity);
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public Task Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public Task Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        #endregion
    }
}
