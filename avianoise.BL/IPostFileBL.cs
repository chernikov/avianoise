using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public interface IPostFileBL : IBaseBL
    {
        PostFile Get(int id);

        List<PostFile> GetList();

        PostFile Create(PostFile entry);

        void Remove(int postFileId);
    }
}
