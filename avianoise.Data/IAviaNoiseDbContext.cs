using Microsoft.EntityFrameworkCore;
using System;
using avianoise.Domain;

namespace avianoise.Data
{
    public interface IavianoiseDbContext : IDisposable
    {
        DbSet<User> Users { get; set; }

        DbSet<Role> Roles { get; set; }

        DbSet<UserRole> UserRoles { get; set; }

        int SaveChanges();
    }
}
