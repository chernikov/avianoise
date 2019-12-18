using avianoise.Data;
using System;

namespace avianoise.DAL
{
    public class BaseRepository
    {

        private readonly Lazy<IAviaNoiseDbContext> lazyContext;

        private IAviaNoiseDbContext context => lazyContext.Value;


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
            using (var dbContext = getDbContext())
            {
                functor(dbContext);
            }
        }

        protected T Query<T>(Func<IAviaNoiseDbContext, T> functor)
        {
            return functor(context);
        }
    }
}
