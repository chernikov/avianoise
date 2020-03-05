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

        public List<Post> GetTree()
        {
            var list = postRepository.Get().ToList();
            return CreateTree(list);
        }

        public List<Post> GetPublished()
        {
            var list = postRepository.Get(p => p.IsPublished).ToList();
            return CreateTree(list);
        }

        public List<Post> GetMenu()
        {
            var list = postRepository.GetMenu();
            return CreateTree(list);
        }

        private List<Post> CreateTree(List<Post> list)
        {
            var tree = new List<Post>();

            foreach (var item in list)
            {
                if (item.PostId.HasValue)
                {
                    var parent = list.FirstOrDefault(p => p.Id == item.PostId);
                    if (parent.Posts == null)
                    {
                        parent.Posts = new List<Post>();
                    }
                    parent.Posts.Add(item);
                }
                else
                {
                    tree.Add(item);
                }
            }
            return tree;
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

        public void SetOrder(List<Post> list)
        {
            foreach (var item in list)
            {
                if (item.Posts != null && item.Posts.Count > 0)
                {
                    SetOrder(item.Posts);
                }
            }
            postRepository.SetOrder(list);
        }
    }
}
