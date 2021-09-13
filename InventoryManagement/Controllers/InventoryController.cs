using InventoryManagement.DataBaseLayer;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace InventoryManagement.Controllers
{
    public class InventoryController : ApiController
    {
        InventoryBusiness _inventoryBusiness = new InventoryBusiness();

        [HttpGet]
        public async Task<List<InventoryViewModel>> GetAllInventoryData()
        {
            return await _inventoryBusiness.GetAllInventoryDataAtBL();
        }

        [HttpGet]
        public async Task<InventoryViewModel> GetInventoryDataById(int Id)
        {
            return await _inventoryBusiness.GetInventoryDataByIdAtBL(Id);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddDataToInventory(InventoryViewModel inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad Request!!!");
            }

            var status = await _inventoryBusiness.SaveDataToInventoryAtBL(inventory);

            return Ok(status);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateInventoryData([FromBody] InventoryViewModel inventory)
        {
            var status = await _inventoryBusiness.SaveDataToInventoryAtBL(inventory);
            if (status == true)
            {
                return Ok("status 200");
            }
            else
            {
                return BadRequest("ID not present!!");
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteInventoryData(int Id)
        {
            var status = await _inventoryBusiness.DeleteInventoryDataAtBL(Id);
            if (status == true)
            {
                return Ok("status 200");
            }
            else
            {
                return BadRequest("ID not present!!");
            }
        }
    }
}