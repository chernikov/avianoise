using avianoise.DAL;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public class PostBL : IPostBL
    {
        private readonly IPostRepository postRepository;

        public PostBL(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        public List<Post> GetList()
        {
            return postRepository.Get().ToList();
        }

        public List<Post> GetPublishedMenu()
        {
            return postRepository.GetPublishedMenu();
        }

        public List<Post> GetMenu()
        {
            return postRepository.GetMenu();
        }

        public Post Get(int id)
        {
            return postRepository.FindById(id);
        }

        public Post Create(Post entry)
        {
            entry.AddedDate = DateTime.Now;
            return postRepository.Create(entry);
        }

        public Post Update(Post entry)
        {
            return postRepository.Update(entry);
        }

        public void Remove(int postId)
        {
            var entry = postRepository.FindById(postId);
            if (entry == null)
            {
                return;
            }
            postRepository.Remove(entry);
        }


    }
}
