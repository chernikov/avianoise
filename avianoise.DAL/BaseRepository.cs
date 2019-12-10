using System;
using avianoise.Data;

namespace avianoise.DAL
{
    public class BaseRepository
    {

        private readonly Lazy<IavianoiseDbContext> lazyContext;

        private IavianoiseDbContext context => lazyContext.Value;


        protected readonly Func<IavianoiseDbContext> getDbContext;

        public BaseRepository(Func<IavianoiseDbContext> getDbContext)
        {
            this.getDbContext = getDbContext;
            lazyContext = new Lazy<IavianoiseDbContext>(() => getDbContext());
        }

        protected T Execute<T>(Func<IavianoiseDbContext, T> functor)
        {
            using (var dbContext = getDbContext())
            {
                return functor(dbContext);
            }
        }

        protected T Query<T>(Func<IavianoiseDbContext, T> functor)
        {
            return functor(context);
        }
    }
}
