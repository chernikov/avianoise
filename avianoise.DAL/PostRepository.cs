using avianoise.Data;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public class PostRepository : GenericRepository<Post>, IPostRepository, IBaseRepository
    {
        public PostRepository(Func<IAviaNoiseDbContext> getDbContext) : base(getDbContext)
        {
        }

        public List<Post> GetMenu()
            => Query(context =>
            {
                return context.Posts
                    .Select(p => new Post()
                    {
                        Id = p.Id,
                        PostId = p.PostId,
                        Order = p.Order,
                        Title = p.Title,
                        AddedDate = p.AddedDate,
                        IsPublished = p.IsPublished,
                    }).ToList();
            });

        public List<Post> GetPublishedMenu()
             => Query(context =>
             {
                 return context.Posts.Where(p => p.IsPublished)
                     .Select(p => new Post()
                     {
                         Id = p.Id,
                         PostId = p.PostId,
                         Order = p.Order,
                         Title = p.Title,
                         AddedDate = p.AddedDate,
                         IsPublished = p.IsPublished,
                     }).ToList();
             });

        public void SetOrder(List<Post> list)
             => Query(context =>
             {
                 foreach (var item in list)
                 {
                     var entry = context.Posts.FirstOrDefault(p => p.Id == item.Id);
                     entry.Order = item.Order;
                 }
                 context.SaveChanges();
             });


        public override Post Update(Post item) =>
            Query(context =>
            {
                var entry = context.Posts.Find(item.Id);

                entry.IsPublished = item.IsPublished;
                entry.Text = item.Text;
                entry.Title = item.Title;
                entry.PostId = item.PostId;
                context.SaveChanges();
                return entry;
            });
    }
}
