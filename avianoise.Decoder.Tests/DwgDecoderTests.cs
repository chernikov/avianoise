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
    public class DwgDecoderTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Decode_Test_TopLeqN()
        {
            string text = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\data\\TopLeqN.dwg");
            var sup = new DwgDecoder();
            var lines = sup.Decode(text);
        }
    }
}
