using avianoise.Data;
using avianoise.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Tests.InMemory
{
    public class MockAvianoiseDbContext : DbContext, IAviaNoiseDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FeedbackFile> FeedbackFiles { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<LogMessage> LogMessages { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Zip> Zips { get; set; }


        public MockAvianoiseDbContext(DbContextOptions options) : base(options)
        {
            Seeder.Seed(this);
        }
    }
}
