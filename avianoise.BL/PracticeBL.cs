using avianoise.DAL;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public class PracticeBL : IPracticeBL
    {
        private readonly IPracticeRepository practiceRepository;

        public PracticeBL(IPracticeRepository practiceRepository)
        {
            this.practiceRepository = practiceRepository;
        }
        public List<Practice> GetList()
        {
            return practiceRepository.Get().ToList();
        }

        public List<Practice> GetTree()
        {
            var list = practiceRepository.Get().ToList();
            return CreateTree(list);
        }



        public List<Practice> GetPublishedMenu()
        {
            var list = practiceRepository.GetPublishedMenu();
            return CreateTree(list);
        }

        public List<Practice> GetMenu()
        {
            var list = practiceRepository.GetMenu();
            return CreateTree(list);
        }


        private List<Practice> CreateTree(List<Practice> list)
        {
            var tree = new List<Practice>();

            foreach (var item in list)
            {
                if (item.PracticeId.HasValue)
                {
                    var parent = list.FirstOrDefault(p => p.Id == item.PracticeId);
                    if (parent.Practices == null)
                    {
                        parent.Practices = new List<Practice>();
                    }
                    parent.Practices.Add(item);
                }
                else
                {
                    tree.Add(item);
                }
            }
            return tree;
        }

        public Practice Get(int id)
        {
            return practiceRepository.FindById(id);
        }

        public Practice Create(Practice entry)
        {
            entry.AddedDate = DateTime.Now;
            return practiceRepository.Create(entry);
        }

        public Practice Update(Practice entry)
        {
            return practiceRepository.Update(entry);
        }

        public void Remove(int practiceId)
        {
            var entry = practiceRepository.FindById(practiceId);
            if (entry == null)
            {
                return;
            }
            practiceRepository.Remove(entry);
        }

        public void SetOrder(List<Practice> list)
        {
            foreach (var item in list)
            {
                if (item.Practices != null && item.Practices.Count > 0)
                {
                    SetOrder(item.Practices);
                }
            }
            practiceRepository.SetOrder(list);
        }


    }
}
