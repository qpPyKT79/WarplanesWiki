using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WarplainsDomain.Abstract;
using WarplainsDomain.Entities;
using WarplanesWiki.Controllers;
using WarplanesWiki.Models;

namespace WarplanesWiki.Tests.Controllers
{
    [TestFixture]
    internal class NavigationControllerTest
    {
        private Mock<IWarplaneRepository> sutMock;
        private NavigationController sutController;

        [TestFixtureSetUp]
        public void Init()
        {
            sutMock = new Mock<IWarplaneRepository>();
            sutMock.Setup(m => m.Warplanes).Returns(new Warplane[]
            {
                new Warplane {WarplaneID = 1, Name = "P1", Category = WarplaneCategoty.UAV},
                new Warplane {WarplaneID = 2, Name = "P2", Category = WarplaneCategoty.UAV},
                new Warplane {WarplaneID = 3, Name = "P3", Category =  WarplaneCategoty.Hedgehopper},
                new Warplane {WarplaneID = 4, Name = "P4", Category = WarplaneCategoty.FighterBomber},
            }.AsQueryable());
            sutController = new NavigationController(sutMock.Object);
        }

        [Test]
        public void Can_Create_Categories()
        {
            var results = ((IEnumerable<WarplaneCategoty>) sutController.Menu().Model).ToArray();
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0], WarplaneCategoty.UAV);
            Assert.AreEqual(results[1], WarplaneCategoty.Hedgehopper);
            Assert.AreEqual(results[2], WarplaneCategoty.FighterBomber);

        }

        [Test]
        public void Indicates_Selected_Category()
        {
            var categoryToSelect = WarplaneCategoty.UAV;
            string result = sutController.Menu((int)categoryToSelect).ViewBag.SelectedCategory;
            Assert.AreEqual(categoryToSelect, result);
        }
    }
}
