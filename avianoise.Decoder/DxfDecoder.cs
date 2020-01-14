using IxMilia.Dxf;
using IxMilia.Dxf.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace avianoise.Decoder
{
    public class DxfDecoder : IDecoder
    {
        public List<Line> Decode(string content)
        {
            var list = new List<Line>();
            DxfFile dxfFile;
            using (var fs = GenerateStreamFromString(content))
            {
                dxfFile = DxfFile.Load(fs);
            }

            foreach (var entity in dxfFile.Entities)
            {
                switch (entity.EntityType)
                {
                    case DxfEntityType.LwPolyline:
                        list.Add(GetLwPolyline(entity));
                        break;
                    case DxfEntityType.Polyline:
                        list.Add(GetPolyline(entity));
                        break;
                }
            }
            return list;
        }
        private Line GetPolyline(DxfEntity entity)
        {
            var polyline = entity as DxfPolyline;
            var line = new Line()
            {
                Name = polyline.Layer
            };
            var index = 1;
            foreach (var vertex in polyline.Vertices)
            {
                line.Points.Add(new Point()
                {
                    Index = index,
                    Lat = vertex.Location.Y,
                    Lng = vertex.Location.X
                });
                index++;
            }
            return line;
        }


        private Line GetLwPolyline(DxfEntity entity)
        {
            var polyline = entity as DxfLwPolyline;
            var line = new Line()
            {
                Name = polyline.Layer
            };
            var index = 1;
            foreach (var vertex in polyline.Vertices)
            {
                line.Points.Add(new Point()
                {
                    Index = index,
                    Lat = vertex.Y,
                    Lng = vertex.X
                });
                index++;
            }
            return line;
        }

        private Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
