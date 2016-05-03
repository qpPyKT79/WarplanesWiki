using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WarplainsDomain.Entities;
using WarplanesWiki.Models;

namespace WarplanesWiki.Tests.Models
{
    [TestFixture]
    class ComparisonTests
    {
        private Comparison sut;
        private Warplane p1;
        private Warplane p2;
        [TestFixtureSetUp]
        public void Init()
        {
            p1 = new Warplane { WarplaneID = 1, Name = "P1" };
            p2 = new Warplane { WarplaneID = 2, Name = "P2" };
            sut = new Comparison();
        }

        [Test]
        public void Can_Add_New_Lines()
        {
            sut.AddPlane(p1);
            sut.AddPlane(p2);
            var results = sut.Planes.OrderBy(x=>x.Name).ToArray();
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0], p1);
            Assert.AreEqual(results[1], p2);
        }
        [Test]
        public void Can_Delete_Some_Lines()
        {
            sut.AddPlane(p1);
            sut.AddPlane(p2);
            sut.RemovePlane(p1);
            var results = sut.Planes.OrderBy(x => x.Name).ToArray();
            Assert.AreEqual(results.Length, 1);
            Assert.AreEqual(results[0], p2);
        }
        [Test]
        public void Cant_Delete_two_times()
        {
            sut.AddPlane(p1);
            sut.AddPlane(p2);
            sut.RemovePlane(p1);
            sut.RemovePlane(p1);
            var results = sut.Planes.OrderBy(x => x.Name).ToArray();
            Assert.AreEqual(results.Length, 1);
            Assert.AreEqual(results[0], p2);
        }

        [Test]
        public void Cant_Delete_unexisted_plane()
        {
            sut.AddPlane(p1);
            sut.AddPlane(p2);
            var p3 = new Warplane() {WarplaneID = 3, Name = "P3"};
            var results = sut.Planes.OrderBy(x => x.Name).ToArray();
            sut.RemovePlane(p3);
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0], p1);
            Assert.AreEqual(results[1], p2);
        }
    }
}
