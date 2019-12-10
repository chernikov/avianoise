using System.Threading.Tasks;
using avianoise.Domain;

namespace avianoise.DAL
{
    public interface IUserAuthRepository : IBaseRepository
    {
        User Get(int id);

        Task<User> GetUserByEmailAsync(string userEmail);

        User GetByEmailAndPassword(string email, string password);

    }
}
