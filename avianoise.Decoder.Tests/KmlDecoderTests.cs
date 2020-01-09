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
    public class KmlDecoderTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Decode_Test_gml_current2018_laeqnight()
        {
            string text = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\data\\gml_current2018_laeqnight.kml");
            var sup = new KmlDecoder();
            var lines = sup.Decode(text);

            /*Assert.AreEqual(3, lines.Count);
            Assert.AreEqual(263, lines[0].Points.Count);*/
        }

    }
}
