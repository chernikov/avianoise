using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity item);

        TEntity Update(TEntity item);

        void Remove(TEntity item);

        TEntity FindById(int id);

        IEnumerable<TEntity> Get();

        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
    }
}
