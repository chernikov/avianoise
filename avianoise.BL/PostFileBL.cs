using avianoise.DAL;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public class PostFileBL : IPostFileBL
    {
        private readonly IPostFileRepository postFileRepository;

        public PostFileBL(IPostFileRepository postFileRepository)
        {
            this.postFileRepository = postFileRepository;
        }

        public PostFile Get(int id)
        {
            return postFileRepository.FindById(id);
        }

        public List<PostFile> GetList()
        {
            return postFileRepository.Get().ToList();
        }

        public PostFile Create(PostFile entry)
        {
            entry.AddedDate = DateTime.Now;
            return postFileRepository.Create(entry);
        }

        public void Remove(int postFileId)
        {
            var entry = postFileRepository.FindById(postFileId);
            if (entry == null)
            {
                return;
            }
            postFileRepository.Remove(entry);
        }
    }
}
