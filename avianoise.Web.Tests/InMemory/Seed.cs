using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Tests.InMemory
{
    public abstract class Seed<T> where T : class
    {
        protected List<T> data;

        public Seed()
        {
            data = Init();
        }

        public abstract List<T> Init();


        public void SeedInto(DbContext context)
        {
            context.Set<T>().AddRange(data);
            context.SaveChanges();
        }
    }
}
