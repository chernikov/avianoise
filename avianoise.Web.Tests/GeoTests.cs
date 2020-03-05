using avianoise.Data;
using avianoise.Web.Helpers;
using avianoise.Web.Helpers.Classes;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace avianoise.Web.Tests
{
    public class GeoTests
    {
        private IAviaNoiseDbContext db;

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AviaNoiseDbContext>();
            optionsBuilder.UseSqlServer("Server=(local);Initial Catalog=avianoise;Trusted_Connection=True;MultipleActiveResultSets=true");
            db = new AviaNoiseDbContext(optionsBuilder.Options);
        }

        [TearDown]
        public void TearDown()
        {
            db.Dispose();
        }

        [Test]
        public void PointInSquare()
        {
            var polyline = new List<PointF>()
            {
                new PointF(1, 1), new PointF(-1, 1), new PointF(-1, -1), new PointF(1, -1)
            };
            var point = new PointF(0, 0);

            var isInPolygon = GeoHelper.IsInPolygon(polyline, point);

            Assert.IsTrue(isInPolygon);
        }

        [Test]
        public void PointOutSquare()
        {
            var polyline = new List<PointF>()
            {
                new PointF(1, 1), new PointF(-1, 1), new PointF(-1, -1), new PointF(1, -1)
            };
            var point = new PointF(2, 2);

            var isInPolygon = GeoHelper.IsInPolygon(polyline, point);

            Assert.IsFalse(isInPolygon);
        }

        [Test]
        public void PointInPolyline()
        {
            var polyline = new List<PointF>()
            {
                new PointF(1, 1), new PointF(1, 2), new PointF(3, 2), new PointF(3, 7),  new PointF(1, 7),  new PointF(1, 8),  new PointF(6, 8),  new PointF(4, 1),
            };
            var point1 = new PointF((float)2.5, (float)1.5);
            var point2 = new PointF((float)3.5, 4);

            var isInPolygon1 = GeoHelper.IsInPolygon(polyline, point1);
            var isInPolygon2 = GeoHelper.IsInPolygon(polyline, point2);

            Assert.IsTrue(isInPolygon1);
            Assert.IsTrue(isInPolygon2);
        }
    }
}