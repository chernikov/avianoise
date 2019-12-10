using Microsoft.EntityFrameworkCore;
using avianoise.Domain;

namespace avianoise.Data
{
    public class Seeder
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Code = "admin",
                Name = "Administrator"
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 2,
                Code = "user",
                Name = "Regular User"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Administrator",
                Email = "admin@avianoise.net",
                Password = "123456"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                Name = "Regular User",
                Email = "user@avianoise.net",
                Password = "123456"
            });

            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                Id = 1,
                RoleId = 1,
                UserId = 1
            });
            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                Id = 2,
                RoleId = 2,
                UserId = 2
            });
        }
    }
}
