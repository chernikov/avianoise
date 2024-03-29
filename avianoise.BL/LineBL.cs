﻿using avianoise.DAL;
using avianoise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.BL
{
    public class LineBL : ILineBL
    {
        private readonly ILineRepository lineRepository;

        public LineBL(ILineRepository lineRepository)
        {
            this.lineRepository = lineRepository;
        }
        public Line GetById(int id)
        {
            return lineRepository.GetById(id);
        }

        public List<Line> GetListByAirport(int airportId)
        {
            return lineRepository.GetListByAirport(airportId);
        }

        public List<Line> GetByFileId(int fileId)
        {
            return lineRepository.GetByFileId(fileId);
        }

        public Line Create(Line entry)
        {
            return lineRepository.Create(entry);
        }

        public Line Update(Line entry)
        {
            return lineRepository.Update(entry);
        }

        public void Delete(int lineId)
        {
            lineRepository.Delete(lineId);
        }

        public void CreatePoints(List<Point> points)
        {
            lineRepository.CreatePoints(points);
        }

        public void DeleteLinesByFileId(int fileId)
        {
            lineRepository.DeleteLinesByFileId(fileId);
        }


    }
}
