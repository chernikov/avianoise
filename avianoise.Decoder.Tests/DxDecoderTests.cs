using NUnit.Framework;
using System.IO;

namespace avianoise.Decoder.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Decode_Test1()
        {
            string text = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\data\\test1.dxf");
            var sup = new DxfDecoder();
            var lines = sup.Decode(text);
            Assert.AreEqual(3, lines.Count);
            Assert.AreEqual(263, lines[0].Points.Count);
        }

        [Test]
        public void Decode_Test2()
        {
            string text = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\data\\test2.dxf");
            var sup = new DxfDecoder();
            var lines = sup.Decode(text);
            Assert.Pass();
        }
    }
}