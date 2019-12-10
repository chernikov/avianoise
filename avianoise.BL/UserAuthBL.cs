using avianoise.DAL;
using avianoise.Domain;

namespace avianoise.BL
{
    public class UserAuthBL : IUserAuthBL
    {
        private readonly IUserAuthRepository userAuthRepository;

        public UserAuthBL(IUserAuthRepository userAuthRepository)
        {
            this.userAuthRepository = userAuthRepository;
        }

        public User GetUserById(int id)
        {
            return userAuthRepository.Get(id);
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return userAuthRepository.GetByEmailAndPassword(email, password);
        }
    }
}
