using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Decoder
{
    public class GeoJsonDecoder : IDecoder
    {
        public List<Line> Decode(string content)
        {
            var list = new List<Line>();
            var jobj = JObject.Parse(content);
            var features = jobj["features"] as JArray;
            foreach (JObject feature in features)
            {
                var geometry = feature["geometry"];
                if (geometry["type"].Value<string>() == "LineString")
                {
                    var name = feature["properties"]["Layer"].Value<string>();
                    var coordinates = geometry["coordinates"] as JArray;
                    var line = new Line()
                    {
                        Name = name,
                        Points = new List<Point>()
                    };
                    var index = 1;
                    foreach (var coordinate in coordinates)
                    {
                        line.Points.Add(new Point()
                        {
                            Index = index,
                            Lat = coordinate[0].Value<double>(),
                            Lng = coordinate[1].Value<double>(),
                        });
                        index++;
                    }
                    list.Add(line);
                }
            }
            return list;
        }
    }
}
