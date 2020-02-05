using avianoise.SL.Options;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace avianoise.SL.Tests
{
    [TestFixture]
    public class GoogleMapSLTests
    {
        private IOptions<GoogleMapOptions> options;

        [SetUp]
        public void Setup()
        {

            options = Microsoft.Extensions.Options.Options.Create(new GoogleMapOptions()
            {
                Key = "AIzaSyB2THP6w4xTtyrFIE4gR_6ZnJqYSl_5cfI"
            });
        }

        [Test]
        public void GetLocationByNowhere()
        {
            var su = GetGoogleMapSL();

            var location = su.GetLocationByAddress("dsfjkasdfiondsfk", out string fullResult);
            Assert.IsNull(location);
            Assert.Pass();
        }

        [Test]
        public void GetLocationByKiev()
        {
            var su = GetGoogleMapSL();
            var location = su.GetLocationByAddress("Україна, Київ", out string fullResult);
            Assert.IsNotNull(location);
            Assert.Pass();
        }

        private IGoogleMapSL GetGoogleMapSL()
        {
            return new GoogleMapSL(options);
        }
    }
}