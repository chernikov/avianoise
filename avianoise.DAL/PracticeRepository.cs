using avianoise.Data;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public class PracticeRepository : GenericRepository<Practice>, IPracticeRepository, IBaseRepository
    {
        public PracticeRepository(Func<IAviaNoiseDbContext> getDbContext) : base(getDbContext)
        {
        }

        public List<Practice> GetMenu()
            => Query(context =>
            {
                return context.Practices
                    .Select(p => new Practice()
                    {
                        Id = p.Id,
                        PracticeId = p.PracticeId,
                        Order = p.Order,
                        Title = p.Title,
                        AddedDate = p.AddedDate,
                        IsPublished = p.IsPublished,
                    }).ToList();
            });

        public List<Practice> GetPublishedMenu()
             => Query(context =>
             {
                 return context.Practices.Where(p => p.IsPublished)
                     .Select(p => new Practice()
                     {
                         Id = p.Id,
                         PracticeId = p.PracticeId,
                         Order = p.Order,
                         Title = p.Title,
                         AddedDate = p.AddedDate,
                         IsPublished = p.IsPublished,
                     }).ToList();
             });

        public void SetOrder(List<Practice> list)
             => Query(context =>
             {
                 foreach (var item in list)
                 {
                     var entry = context.Practices.FirstOrDefault(p => p.Id == item.Id);
                     entry.Order = item.Order;
                 }
                 context.SaveChanges();
             });


        public override Practice Update(Practice item) =>
            Query(context =>
            {
                var entry = context.Practices.Find(item.Id);

                entry.IsPublished = item.IsPublished;
                entry.Text = item.Text;
                entry.Title = item.Title;
                entry.PracticeId = item.PracticeId;
                context.SaveChanges();
                return entry;
            });
    }
}
