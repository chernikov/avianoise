using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace avianoise.Decoder
{
    public class KmlDecoder : IDecoder
    {
        public List<Line> Decode(string content)
        {
            var list = new List<Line>();
            var doc = new XmlDocument();
            doc.LoadXml(content);

            var root = doc.DocumentElement;
            var document = root.GetElementsByTagName("Document")[0] as XmlElement;
            var folder = document.GetElementsByTagName("Folder")[0] as XmlElement;
            var placemarks = folder.GetElementsByTagName("Placemark");
            foreach (XmlElement placemark in placemarks)
            {
                var lineStrings = placemark.GetElementsByTagName("LineString");
                if (lineStrings.Count > 0)
                {
                    var lineString = lineStrings[0] as XmlElement;
                    var extendedData = placemark.GetElementsByTagName("ExtendedData")[0] as XmlElement;
                    var schemaData = extendedData.GetElementsByTagName("SchemaData")[0] as XmlElement;
                    var simpleData = schemaData.GetElementsByTagName("SimpleData")[0] as XmlElement;
                    var name = simpleData.InnerText;
                    var coordinates = lineString.GetElementsByTagName("coordinates")[0] as XmlElement;
                    var coordinatesStr = coordinates.InnerText;

                    var parts = coordinatesStr.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    var line = new Line()
                    {
                        Name = name,
                        Points = new List<Point>()
                    };
                    var index = 1;
                    foreach (var coordinate in parts)
                    {
                        var partsCoordinate = coordinate.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        line.Points.Add(new Point()
                        {
                            Index = index,
                            Lng = Double.Parse(partsCoordinate[0]),
                            Lat = Double.Parse(partsCoordinate[1])
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
