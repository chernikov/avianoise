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
                         Title = p.Title,
                         AddedDate = p.AddedDate,
                         IsPublished = p.IsPublished,
                     }).ToList();
             });
    }
}
