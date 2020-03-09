using avianoise.Data;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public class UserRoleRepository : BaseRepository, IUserRoleRepository
    {
        public UserRoleRepository(Func<IAviaNoiseDbContext> getDbContext) : base(getDbContext)
        {
        }

        public void Create(int userId, int roleId) =>
            Query(context =>
            {
                var userRole = new UserRole()
                {
                    UserId = userId,
                    RoleId = roleId
                };
                context.UserRoles.Add(userRole);
                context.SaveChanges();
                return userRole;
            });


        public User GetUserByEmail(string email)
             => Query(context => context.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0));

    }
}
