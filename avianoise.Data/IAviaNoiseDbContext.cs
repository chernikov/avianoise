using avianoise.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace avianoise.Data
{
    public interface IAviaNoiseDbContext : IDisposable
    {
        DbSet<Address> Addresses { get; set; }

        DbSet<Airport> Airports { get; set; }

        DbSet<File> Files { get; set; }

        DbSet<Line> Lines { get; set; }

        DbSet<Point> Points { get; set; }

        DbSet<Role> Roles { get; set; }

        DbSet<User> Users { get; set; }

        DbSet<UserRole> UserRoles { get; set; }

        DbSet<Zip> Zips { get; set; }

        int SaveChanges();
    }
}
