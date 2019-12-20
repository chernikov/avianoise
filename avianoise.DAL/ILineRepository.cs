﻿using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.DAL
{
    public interface ILineRepository : IBaseRepository
    {
        Line GetById(int entryId);

        List<Line> GetListByAirport(int airportId);

        Line Create(Line entry);

        Line Update(Line entry);

        void Delete(int lineId);
    }
}
