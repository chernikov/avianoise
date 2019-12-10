using Newtonsoft.Json;

namespace avianoise.Swagger.Tests.Lab
{
    [JsonConverter(typeof(UserConverter))]
    public class User
    {
        public string UserName { get; set; }
    }
}
