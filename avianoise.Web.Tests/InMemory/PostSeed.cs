using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Tests.InMemory
{
    public class PostSeed : Seed<Post>
    {
        public override List<Post> Init()
        {
            return new List<Post>()
            {
                new Post() {Id = 1, AddedDate = DateTime.Now, IsPublished = true, Order = 1, Title = "Категорії шуму", Text = "Категорії шуму",  },
                new Post() {Id = 2, AddedDate = DateTime.Now, IsPublished = true, Order = 1, PostId = 1, Title = "Підкатегорії шуму 1", Text = "Підкатегорії шуму" },
                new Post() {Id = 3, AddedDate = DateTime.Now, IsPublished = true, Order = 2, PostId = 1, Title = "Підкатегорії шуму 2", Text = "Підкатегорії шуму" },
            };
        }
    }
}
