using avianoise.Data;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(Func<IAviaNoiseDbContext> getDbContext) : base(getDbContext)
        {
        }

        public User Create(User userEntry)
            => Execute(context =>
            {
                context.Users.Add(userEntry);
                context.SaveChanges();
                return userEntry;
            });


        public User GetByEmail(string email)
             => Query(context => context.Users.FirstOrDefault(p => string.Compare(p.Email, email, true) == 0));

        public User GetById(int id)
            => Query(context => context.Users.FirstOrDefault(p => p.Id == id));

    }
}
