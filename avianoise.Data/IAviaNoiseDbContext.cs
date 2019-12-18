using avianoise.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace avianoise.Data
{
    public interface IAviaNoiseDbContext : IDisposable
    {
        DbSet<User> Users { get; set; }

        DbSet<Role> Roles { get; set; }

        DbSet<UserRole> UserRoles { get; set; }

        int SaveChanges();
    }
}
