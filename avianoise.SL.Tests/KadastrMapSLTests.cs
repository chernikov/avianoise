using avianoise.SL.Results;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.SL.Tests
{
    [TestFixture]
    public class KadastrMapSLTests
    {
        public Location PrompryladLocation { get; set; } = new Location()
        {
            Lat = 48.9144078,
            Lng = 24.7127139
        };

        public string PrompryladKadastr = "2610100000:06:003:0227";

        public string NowhereKadastr = "9999900000:06:003:0227";

        [Test]
        public void GetNumberByCurrentXyz()
        {
            var su = GetKadastrMapSL();
            var number = su.GetNumberByXyz(6262418.6621422, 2753765.8284577, 14);
            Assert.IsNotNull(number);
            Assert.Pass();
        }

        [Test]
        public void GetNumberByPrompryladCoordinates()
        {
            var su = GetKadastrMapSL();
            var number = su.GetNumberByLatLng(PrompryladLocation.Lat, PrompryladLocation.Lng);
            Assert.IsNotNull(number);
            Assert.AreEqual(number.ToString(), PrompryladKadastr);
            Assert.Pass();
        }


        [Test]
        public void GetAreaByPrompryladKadastrNumber()
        {
            var su = GetKadastrMapSL();
            var area = su.GetAreaByNumber(KadastrNumber.Parse(PrompryladKadastr));
            Assert.IsNotNull(area);
        }

        [Test]
        public void GetLocationByPrompryladKadastrNumber()
        {
            var su = GetKadastrMapSL();
            var location = su.GetLocationByNumber(KadastrNumber.Parse(PrompryladKadastr));
            Assert.IsNotNull(location);
            Assert.Less(Math.Abs(location.Lat - PrompryladLocation.Lat), 0.001);
            Assert.Less(Math.Abs(location.Lng - PrompryladLocation.Lng), 0.001);
        }

        [Test]
        public void GetInfoByPrompryladKadastrNumber()
        {
            var su = GetKadastrMapSL();
            var info = su.GetInfoByNumber(KadastrNumber.Parse(PrompryladKadastr));
            Assert.IsNotNull(info);
        }


        [Test]
        public void GetInfoByNowhereKadastrNumber()
        {
            var su = GetKadastrMapSL();
            var info = su.GetInfoByNumber(KadastrNumber.Parse(NowhereKadastr));
            Assert.IsNull(info);
        }


        [Test]
        public void GetAreaByNowhereKadastrNumber()
        {
            var su = GetKadastrMapSL();
            var area = su.GetAreaByNumber(KadastrNumber.Parse(NowhereKadastr));
            Assert.IsNull(area);
        }

        private IKadastrMapSL GetKadastrMapSL()
        {
            return new KadastrMapSL();
        }
    }
}
