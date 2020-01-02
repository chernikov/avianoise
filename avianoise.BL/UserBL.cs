using avianoise.DAL;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepository userRepository;
        private readonly IUserRoleRepository userRoleRepository;

        public UserBL(IUserRepository userRepository, IUserRoleRepository userRoleRepository)
        {
            this.userRepository = userRepository;
            this.userRoleRepository = userRoleRepository;
        }

        public void AddRole(User newUser, Role role)
        {
            userRoleRepository.Create(newUser.Id, role.Id);
        }

        public User Create(User userEntry)
        {
            return userRepository.Create(userEntry);
        }

        public User GetByEmail(string email)
        {
            return userRepository.GetByEmail(email);
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }
    }
}
