using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public interface IPostBL : IBaseBL
    {
        List<Post> GetList();

        List<Post> GetPublished();

        Post Get(int id);

        Post Create(Post entry);

        Post Update(Post entry);

        void Remove(int postId);
    }
}
