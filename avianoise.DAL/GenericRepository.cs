using avianoise.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public abstract class GenericRepository<TEntity> : BaseRepository, IGenericRepository<TEntity> where TEntity : class
    {
        public GenericRepository(Func<IAviaNoiseDbContext> getDbContext) : base(getDbContext)
        {
        }

        public virtual IEnumerable<TEntity> Get()
            => QueryDbContext(context =>
            {
                var _dbSet = context.Set<TEntity>();
                return _dbSet.AsNoTracking().ToList();
            });

        public virtual IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
             => QueryDbContext(context =>
             {
                 var _dbSet = context.Set<TEntity>();
                 return _dbSet.AsNoTracking().Where(predicate).ToList();
             });

        public virtual TEntity Create(TEntity item)
            => QueryDbContext(dbContext =>
            {
                var _dbSet = dbContext.Set<TEntity>();
                _dbSet.Add(item);
                dbContext.SaveChanges();
                return item;
            });

        public virtual void Remove(TEntity item)
            => QueryDbContext(context =>
            {
                var _dbSet = context.Set<TEntity>();
                _dbSet.Remove(item);
                context.SaveChanges();
            });


        public virtual TEntity Update(TEntity item)
            => QueryDbContext(context =>
            {
                var _dbSet = context.Set<TEntity>();
                _dbSet.Update(item);
                context.SaveChanges();
                return item;
            });

        public virtual TEntity FindById(int id) =>
            QueryDbContext(context =>
            {
                var _dbSet = context.Set<TEntity>();
                return _dbSet.Find(id);
            });
    }
}
