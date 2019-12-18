using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public interface IUserRoleRepository : IBaseRepository
    {
        void Create(int userId, int roleId);
    }
}
