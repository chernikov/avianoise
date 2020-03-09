using avianoise.Data;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        public AddressRepository(Func<IAviaNoiseDbContext> getDbContext) : base(getDbContext)
        {
        }

        public Address Create(Address entry)
            => Query(context =>
            {
                entry.AddedDate = DateTime.Now;
                entry.SearchLine = entry.SearchLine.Trim().ToLower();
                context.Addresses.Add(entry);
                context.SaveChanges();
                return entry;
            });


        public Address GetBySearchLine(string searchLine)
            => Query(context =>
            {
                var searchLineQuery = searchLine.Trim().ToLower();
                var entry = context.Addresses.FirstOrDefault(p => p.SearchLine == searchLineQuery);
                return entry;
            });
    }
}
