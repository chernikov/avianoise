using System;
using System.Collections.Generic;
using System.Linq;
using avianoise.Data;
using avianoise.Domain;

namespace avianoise.DAL
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(Func<IavianoiseDbContext> getDbContext) : base(getDbContext)
        {

        }


        public IList<Role> GetList() => Query((context) => context.Roles.ToList());
    }
}
