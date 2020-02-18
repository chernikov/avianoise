using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Dto.Results
{
    public class PagedListResult<T>
    {
        public List<T> Items { get; set; }

        public int TotalPages { get; set; }
    }
}
