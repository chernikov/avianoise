using Newtonsoft.Json;
using NUnit.Framework;
using avianoise.Swagger.Tests.Lab;

namespace avianoise.Swagger.Tests
{
    public class JsonTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckJsonConverter()
        {
            var user = new User
            {
                UserName = @"domain\username"
            };

            string json = JsonConvert.SerializeObject(user, Formatting.Indented);

            Assert.Pass();
        }
    }
}