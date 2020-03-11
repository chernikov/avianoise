using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public interface IPracticeBL : IBaseBL
    {
        List<Practice> GetList();

        List<Practice> GetTree();
        List<Practice> GetPublishedMenu();

        List<Practice> GetMenu();

        Practice Get(int id);

        Practice Create(Practice entry);

        Practice Update(Practice entry);

        void Remove(int postId);

        void SetOrder(List<Practice> list);
    }
}
