using avianoise.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace avianoise.Data
{
    public class AviaNoiseDbContext : DbContext, IAviaNoiseDbContext
    {
        public static readonly ILoggerFactory DbContextLoggerFactory;

        static AviaNoiseDbContext()
        {
            //DbContextLoggerFactory = new LoggerFactory();
            //DbContextLoggerFactory.AddConsole();
            //DbContextLoggerFactory.AddNLog();
        }

        public AviaNoiseDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(local);Initial Catalog=avianoise;Trusted_Connection=True;MultipleActiveResultSets=true");
            options.UseLoggerFactory(DbContextLoggerFactory);
            options.EnableSensitiveDataLogging(true);
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            var seeder = new Seeder();
            seeder.Seed(modelBuilder);
        }
    }

}
