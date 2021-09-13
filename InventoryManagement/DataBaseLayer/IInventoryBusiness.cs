using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InventoryManagement.DataBaseLayer
{
    interface IInventoryBusiness
    {
        Task<List<InventoryViewModel>> GetAllInventoryDataAtBL();

        Task<InventoryViewModel> GetInventoryDataByIdAtBL(int Id);

        Task<bool> SaveDataToInventoryAtBL(InventoryViewModel inventory);

        Task<bool> UpdateInventoryDataAtBL(InventoryViewModel inventory);

        Task<bool> DeleteInventoryDataAtBL(int Id);
    }
}