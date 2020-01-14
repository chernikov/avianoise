using avianoise.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using NLog.Extensions.Logging;

namespace avianoise.Data
{
    public class AviaNoiseDbContext : DbContext, IAviaNoiseDbContext
    {
        public static readonly ILoggerFactory DbContextLoggerFactory;

        static AviaNoiseDbContext()
        {
            DbContextLoggerFactory = new LoggerFactory();
            //DbContextLoggerFactory.AddProvider(new ConsoleLoggerProvider());
            //DbContextLoggerFactory.AddConsole();
            DbContextLoggerFactory.AddNLog();
        }

        public AviaNoiseDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Airport> Airports { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Line> Lines { get; set; }

        public DbSet<Point> Points { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Zip> Zips { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("Server=(local);Initial Catalog=avianoise;Trusted_Connection=True;MultipleActiveResultSets=true");
        //    options.UseLoggerFactory(DbContextLoggerFactory);
        //    options.EnableSensitiveDataLogging(true);
        //    base.OnConfiguring(options);
        //}

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
