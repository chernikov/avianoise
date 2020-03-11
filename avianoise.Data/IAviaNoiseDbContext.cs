using avianoise.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace avianoise.Data
{
    public interface IAviaNoiseDbContext : IDisposable
    {
        DbSet<Address> Addresses { get; set; }

        DbSet<Airport> Airports { get; set; }

        DbSet<Feedback> Feedbacks { get; set; }

        DbSet<File> Files { get; set; }

        DbSet<FeedbackFile> FeedbackFiles { get; set; }

        DbSet<Line> Lines { get; set; }

        DbSet<LogMessage> LogMessages { get; set; }

        DbSet<Point> Points { get; set; }

        DbSet<Post> Posts { get; set; }

        DbSet<Practice> Practices { get; set; }

        DbSet<Role> Roles { get; set; }

        DbSet<User> Users { get; set; }

        DbSet<UserRole> UserRoles { get; set; }

        DbSet<Zip> Zips { get; set; }

        int SaveChanges();
    }
}
