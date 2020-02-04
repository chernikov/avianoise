using avianoise.SL.Options;
using avianoise.SL.Results;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.SL
{
    public class GoogleMapSL : IGoogleMapSL
    {
        private readonly string coordinatesByAddressUrlTemplate = "https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}";

        private readonly string _key;

        public GoogleMapSL(IOptions<GoogleMapOptions> options)
        {
            _key = options.Value.Key;
        }


        public Location GetLocationByAddress(string Address, out string fullResult)
        {
            var url = string.Format(coordinatesByAddressUrlTemplate, Address, _key);
            using (var client = new HttpClient())
            {
                var resultTask = client.GetStringAsync(url);
                fullResult = resultTask.Result;
            }
            var obj = JObject.Parse(fullResult);

            if (obj["status"].Value<string>() == "OK" && obj["results"].Count() > 0)
            {
                var geometry = obj["results"][0]["geometry"];

                var location = new Location()
                {
                    Lat = geometry["location"]["lat"].Value<double>(),
                    Lng = geometry["location"]["lng"].Value<double>()
                };
                return location;
            }
            return null;
        }
    }
}
