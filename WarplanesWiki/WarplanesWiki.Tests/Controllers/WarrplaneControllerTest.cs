using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using WarplainsDomain.Abstract;
using WarplainsDomain.Entities;
using WarplanesWiki.Controllers;
using WarplanesWiki.Models;
using Assert = NUnit.Framework.Assert;

namespace WarplanesWiki.Tests.Controllers
{
    [TestFixture]
    public class WarrplaneControllerTest
    {
        private Mock<IWarplaneRepository> sutMock;
        private WarplaneController sutController;

        [TestFixtureSetUp]
        public void Init()
        {
            sutMock = new Mock<IWarplaneRepository>();
            
            sutMock.Setup(m => m.Warplanes).Returns(new Warplane[]
            {
                new Warplane {WarplaneID = 1, Name = "P1", Category = WarplaneCategoty.UAV},
                new Warplane {WarplaneID = 2, Name = "P2", Category = WarplaneCategoty.Hedgehopper},
                new Warplane {WarplaneID = 3, Name = "P3", Category = WarplaneCategoty.FighterBomber},
                new Warplane {WarplaneID = 4, Name = "P4", Category = WarplaneCategoty.Hedgehopper},
                new Warplane {WarplaneID = 5, Name = "P5", Category = WarplaneCategoty.Scout}
            }.AsQueryable());
            sutController = new WarplaneController(sutMock.Object);
            sutController.PageSize = 3;
        }

        [Test]
        public void Can_Send_Pagination_View_Model()
        {
            var result = (WarplanesListViewModel) sutController.List(0, "", 2).Model;
            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        [Test]
        public void Can_Paginate()
        {
            var result = ((WarplanesListViewModel) sutController.List(0, "", 2).Model).Warplanes.ToArray();
            Assert.IsTrue(result.Length == 2);
            Assert.AreEqual(result[0].Name, "P4");
            Assert.AreEqual(result[1].Name, "P5");
        }

        [Test]
        public void Can_Filter_Products()
        {
            var result = ((WarplanesListViewModel) sutController.List(1, "", 1).Model).Warplanes.ToArray();
            // Assert
            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].Name == "P2" && result[0].Category == WarplaneCategoty.Hedgehopper);
            Assert.IsTrue(result[1].Name == "P4" && result[1].Category == WarplaneCategoty.Hedgehopper);
        }
    }

}
