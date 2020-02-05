using avianoise.SL.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace avianoise.SL
{
    public class KadastrMapSL : IKadastrMapSL
    {
        private readonly string getObjectInfoUrl = "https://map.land.gov.ua/kadastrova-karta/getobjectinfo";

        private readonly string getAreaByNumberTemplate = "https://map.land.gov.ua/kadastrova-karta/find-Parcel?cadnum={0}&activeArchLayer=0";

        private readonly string HtmlKadastrRegexTemplate = "<strong>(?<number>.*?)</strong>";

        private const int Extent = 6378137;

        public KadastrNumber GetNumberByXyz(double x, double y, int zoom)
        {
            string result;
            var values = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("x", x.ToString()),
                new KeyValuePair<string, string>("y", y.ToString()),
                new KeyValuePair<string, string>("zoom", zoom.ToString()),
                new KeyValuePair<string, string>("actLayers[]", "kadastr")
            };

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36");
                using (var content = new FormUrlEncodedContent(values))
                {
                    var responseTask = client.PostAsync(getObjectInfoUrl, content);
                    var response = responseTask.Result;
                    var resultTask = response.Content.ReadAsStringAsync();
                    result = resultTask.Result;
                }
            }

            var obj = JObject.Parse(result);

            if (obj["pusto"] != null && obj["pusto"].Value<int>() == 1)
            {
                return null;
            }
            if (obj["dilanka"] == null)
            {
                return null;
            }
            var htmlInfo = obj["dilanka"].Value<string>();

            var regex = new Regex(HtmlKadastrRegexTemplate, RegexOptions.None);

            var matches = regex.Matches(htmlInfo);

            if (matches.Count > 0)
            {
                var number = matches[0].Groups[1].Value;
                return KadastrNumber.Parse(number);
            }
            return null;
        }

        public KadastrNumber GetNumberByLatLng(double lat, double lng)
        {
            var zoom = 16;
            var tilePoint = WorldToTilePos(lat, lng, zoom);
            var tileSize = (Math.PI * Extent * 2) / Math.Pow(2, zoom);
            var y = -1 * Math.PI * Extent + ((tilePoint.X) * tileSize);
            var x = Math.PI * Extent - ((tilePoint.Y) * tileSize);
            return GetNumberByXyz(x, y, zoom);
        }

        public XyAreaD GetAreaByNumber(KadastrNumber number)
        {
            var url = string.Format(getAreaByNumberTemplate, number);
            string result;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36");
                var resultTask = client.GetStringAsync(url);
                result = resultTask.Result;
            }

            var objResult = JsonConvert.DeserializeObject<KadastrResult<XyArea>>(result);
            if (objResult.Status && objResult.Data.Count > 0 && objResult.Data[0].St_xmax != null)
            {
                var data = objResult.Data[0];
                return data;
            }
            return null;
        }

        public Location GetLocationByNumber(KadastrNumber number)
        {
            var area = GetAreaByNumber(number);
            if (area == null)
            {
                return null;
            }

            var point = area.GetCenter();
            var location = XyToLocation(point);
            return location;
        }



        public KadastrInfo GetInfoByNumber(KadastrNumber number)
        {
            throw new NotImplementedException();
        }



        private Location XyToLocation(Point point)
        {
            var zoom = 16;
            var tileSize = (Math.PI * Extent * 2) / Math.Pow(2, zoom);
            var tileX = (point.Y + Math.PI * Extent) / tileSize;
            var tileY = -1 * (point.X - Math.PI * Extent) / tileSize;

            var location = TileToWorldPos(tileY, tileX, zoom);
            return new Location()
            {
                Lng = -location.X,
                Lat = -location.Y,
            };
        }


        /// <summary>
        /// ref https://wiki.openstreetmap.org/wiki/Slippy_map_tilenames#C.23
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        private Point WorldToTilePos(double lat, double lng, int zoom)
        {
            var p = new Point
            {
                X = (float)((lng + 180.0) / 360.0 * (1 << zoom)),
                Y = (float)((1.0 - Math.Log(Math.Tan(lat * Math.PI / 180.0) + 1.0 / Math.Cos(lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << zoom))
            };
            return p;
        }

        /// <summary>
        /// ref https://wiki.openstreetmap.org/wiki/Slippy_map_tilenames#C.23
        /// </summary>
        /// <param name="tileX"></param>
        /// <param name="tileY"></param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        private Point TileToWorldPos(double tileX, double tileY, int zoom)
        {
            Point p = new Point();
            double n = Math.PI - ((2.0 * Math.PI * tileY) / Math.Pow(2.0, zoom));

            p.X = (float)((tileX / Math.Pow(2.0, zoom) * 360.0) - 180.0);
            p.Y = (float)(180.0 / Math.PI * Math.Atan(Math.Sinh(n)));

            return p;
        }

    }
}
