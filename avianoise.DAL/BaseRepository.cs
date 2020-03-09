using avianoise.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace avianoise.DAL
{
    public class BaseRepository
    {

        private readonly Lazy<IAviaNoiseDbContext> lazyContext;

        protected IAviaNoiseDbContext context => lazyContext.Value;

        protected DbContext dbContext => lazyContext.Value as DbContext;


        private readonly Func<IAviaNoiseDbContext> getDbContext;

        public BaseRepository(Func<IAviaNoiseDbContext> getDbContext)
        {
            this.getDbContext = getDbContext;
            lazyContext = new Lazy<IAviaNoiseDbContext>(() => getDbContext());
        }

        protected void Query(Action<IAviaNoiseDbContext> functor)
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


        protected void QueryDbContext(Action<DbContext> functor)
        {
            functor(dbContext);
        }
    }
}
