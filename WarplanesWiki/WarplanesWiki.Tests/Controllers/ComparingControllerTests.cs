using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using WarplainsDomain.Abstract;
using WarplainsDomain.Entities;
using WarplanesWiki.Models;
using Assert = NUnit.Framework.Assert;

namespace WarplanesWiki.Tests.Controllers
{
    [TestFixture]
    class ComparingControllerTests
    {
        private ComparingController sutController;
        private Mock<IWarplaneRepository> sutMock;

        [TestFixtureSetUp]
        public void Index()
        {
            sutMock = new Mock<IWarplaneRepository>();
            sutMock.Setup(m => m.Warplanes).Returns(new Warplane[]
            {
                new Warplane {WarplaneID = 1, Name = "P1", Category = WarplaneCategoty.Bomber},
            }.AsQueryable());
        }

        [Test]
        public void Can_Add_To_Cart()
        {
            var comparison = new Comparison();
            sutController = new ComparingController(sutMock.Object);
            sutController.AddToCompare(comparison, 1, null);
            Assert.AreEqual(comparison.Planes.Count(), 1);
            Assert.AreEqual(comparison.Planes.ToArray()[0].WarplaneID, 1);
        }
        [Test]
        public void Adding_Product_To_Cart_Goes_To_Cart_Screen()
        {
            var comparison = new Comparison();
            sutController = new ComparingController(sutMock.Object);
            var result = sutController.AddToCompare(comparison, 2, "myUrl");
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }
        [Test]
        public void Can_View_Cart_Contents()
        {
            var comparison = new Comparison();
            sutController = new ComparingController(null);
            var result = (ComparisonIndexViewModel)sutController.Index(comparison, "myUrl").ViewData.Model;
            Assert.AreSame(result.CompareCollection, comparison);
            Assert.AreEqual(result.ReturnUrl, "myUrl");
        }
    }
}
