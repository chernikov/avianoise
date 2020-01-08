using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public interface ILineBL : IBaseBL
    {
        Line GetById(int id);

        List<Line> GetListByAirport(int airportId);

        Line Create(Line entry);

        Line Update(Line entry);

        void Delete(int lineId);

        void CreatePoints(List<Point> points);
    }
}
