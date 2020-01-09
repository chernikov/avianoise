using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Decoder.Tests
{
    [TestFixture]
    public class GeoJsonDecoderTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Decode_Test_GML_current2018_LaeqNight()
        {
            string text = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\data\\GML_current2018_LaeqNight.geojson");
            var sup = new GeoJsonDecoder();
            var lines = sup.Decode(text);

            /*Assert.AreEqual(3, lines.Count);
            Assert.AreEqual(263, lines[0].Points.Count);*/
        }
    }
}
