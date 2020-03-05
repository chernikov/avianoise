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

        List<Post> GetTree();

        List<Post> GetPublished();

        List<Post> GetMenu();

        Post Get(int id);

        Post Create(Post entry);

        Post Update(Post entry);

        void Remove(int postId);

        void SetOrder(List<Post> list);
    }
}
