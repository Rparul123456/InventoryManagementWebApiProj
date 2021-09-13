using InventoryManagement.Controllers;
using InventoryManagement.DataBaseLayer;
using InventoryManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace InventoryManagement.Tests.Controllers
{
    [TestClass]
    public class UnitTestController
    {
        InventoryBusiness _business = new InventoryBusiness();
        [TestMethod]
        public async Task GetAllInventoryDataAsync_CheckCountIsEqual()
        {
            var testProducts = GetTestProducts();

            var result = await _business.GetAllInventoryDataAtBL() as List<InventoryViewModel>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }

        [TestMethod]
        public async Task GetProduct_ShouldReturnCorrectProduct()
        {
            var testProducts = GetTestProducts();

            var result = await _business.GetInventoryDataByIdAtBL(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(testProducts[0].Name, result.Name);
        }

        [TestMethod]
        public async Task AddDataToInventoryAsync_UnitTestCase()
        {
            var sampleData = new InventoryViewModel()
            {
                Name = "Sample Data",
                Description = "test data",
                Price = 100
            };

            var status = await _business.SaveDataToInventoryAtBL(sampleData);
            Assert.IsTrue(status);
        }

        [TestMethod]
        public async Task UpdateInventoryDataAsync_UnitTestCase()
        {
            var sampleData = new InventoryViewModel()
            {
                Id = 13,
                Name = "Sample Data",
                Description = "test data",
                Price = 100
            };

            var status = await _business.UpdateInventoryDataAtBL(sampleData);
            Assert.IsTrue(status);
        }

        [TestMethod]
        public async Task DeleteInventoryDataAsync_UnitTestCase()
        {
            var status = await _business.DeleteInventoryDataAtBL(14);
            Assert.IsTrue(status);
        }

        private List<InventoryViewModel> GetTestProducts()
        {
            var testProducts = new List<InventoryViewModel>();
            testProducts.Add(new InventoryViewModel { Id = 1, Name = "Demo1", Description = "test data", Price = 1 });
            testProducts.Add(new InventoryViewModel { Id = 2, Name = "Demo2", Description = "test data", Price = 3.75 });
            //testProducts.Add(new InventoryViewModel { Id = 3, Name = "Demo3", Description = "test data", Price = 16.99 });
            //testProducts.Add(new InventoryViewModel { Id = 4, Name = "Demo4", Description = "test data", Price = 11.00 });

            return testProducts;
        }
    }
}
