using avianoise.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace avianoise.DAL
{
    public class BaseRepository
    {

        private readonly Lazy<IAviaNoiseDbContext> lazyContext;

        private IAviaNoiseDbContext context => lazyContext.Value;

        private DbContext dbContext => lazyContext.Value as DbContext;


        protected readonly Func<IAviaNoiseDbContext> getDbContext;

        public BaseRepository(Func<IAviaNoiseDbContext> getDbContext)
        {
            this.getDbContext = getDbContext;
            lazyContext = new Lazy<IAviaNoiseDbContext>(() => getDbContext());
        }

        protected T Execute<T>(Func<IAviaNoiseDbContext, T> functor)
        {
            using (var dbContext = getDbContext())
            {
                return functor(dbContext);
            }
        }

        protected void Execute(Action<IAviaNoiseDbContext> functor)
        {
            functor(context);
        }

        protected T Query<T>(Func<IAviaNoiseDbContext, T> functor)
        {
            return functor(context);
        }

        protected T QueryDbContext<T>(Func<DbContext, T> functor)
        {
            return functor(dbContext);
        }

        protected T ExecuteDbContext<T>(Func<DbContext, T> functor)
        {
            using (var dbContext = getDbContext() as DbContext)
            {
                return functor(dbContext);
            }
        }

        protected void ExecuteDbContext(Action<DbContext> functor)
        {
            using (var dbContext = getDbContext() as DbContext)
            {
                functor(dbContext);
            }
        }
    }
}
