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
                new Warplane {WarplaneID = 1, Name = "P1"},
                new Warplane {WarplaneID = 2, Name = "P2"},
                new Warplane {WarplaneID = 3, Name = "P3"},
                new Warplane {WarplaneID = 4, Name = "P4"},
                new Warplane {WarplaneID = 5, Name = "P5"}
            }.AsQueryable());
            sutController = new WarplaneController(sutMock.Object);
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            
            sutController.PageSize = 3;
            // Act
            var result = (WarplanesListViewModel)sutController.List(2).Model;
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
            sutController.PageSize = 3;
            var result = ((WarplanesListViewModel)sutController.List(2).Model).Warplanes.ToArray();
            Assert.IsTrue(result.Length == 2);
            Assert.AreEqual(result[0].Name, "P4");
            Assert.AreEqual(result[1].Name, "P5");

        }
    }
}
