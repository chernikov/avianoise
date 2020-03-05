using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Tests.InMemory
{
    public static class Seeder
    {
        public static void Seed(DbContext dbContext)
        {
            new PostSeed().SeedInto(dbContext);
        }
    }
}
