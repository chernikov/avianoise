using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public interface IUserBL : IBaseBL
    {
        User GetById(int id);

        User GetByEmail(string email);

        User Create(User userEntry);

        void AddRole(User newUser, Role role);
    }
}
