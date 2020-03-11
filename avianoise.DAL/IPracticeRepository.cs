using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public interface IPracticeRepository : IGenericRepository<Practice>, IBaseRepository
    {
        List<Practice> GetMenu();

        List<Practice> GetPublishedMenu();

        void SetOrder(List<Practice> list);


    }
}
