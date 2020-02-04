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
            var number = su.GetNumberByLatLng(48.9144078, 24.7127139);
            Assert.IsNotNull(number);
            Assert.AreEqual(number.ToString(), "2610100000:06:003:0227");
            Assert.Pass();
        }


        private IKadastrMapSL GetKadastrMapSL()
        {
            return new KadastrMapSL();
        }
    }
}
