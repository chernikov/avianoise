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

        private readonly string getInfoByNumberTemplate = "https://map.land.gov.ua/kadastrova-karta/get-parcel-Info?koatuu={0}&zone={1}&quartal={2}&parcel={3}";

        private readonly string HtmlKadastrRegexTemplate = "<strong>(?<number>.*?)</strong>";



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
            var location = new Location() { Lat = lat, Lng = lng };
            var point = GeoLatLngHelper.LocationToXy(location);
            return GetNumberByXyz(point.X, point.Y, GeoLatLngHelper.Zoom);
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
            var location = GeoLatLngHelper.XyToLocation(point);
            return location;
        }

        public KadastrInfo GetInfoByNumber(KadastrNumber number)
        {
            var getInfoUrl = string.Format(getInfoByNumberTemplate, number.Koatuu, number.Zone, number.Kvartal, number.Parcel);
            string result;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36");
                var responseTask = client.GetStringAsync(getInfoUrl);
                result = responseTask.Result;
            }
            var objResult = JsonConvert.DeserializeObject<KadastrResult<KadastrInfo>>(result);
            if (objResult.Status && objResult.Data.Count > 0)
            {
                var data = objResult.Data[0];
                return data;
            }
            return null;
        }


    }
}
