using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InventoryManagement.DataBaseLayer
{
    public class InventoryBusiness : IInventoryBusiness
    {
        public async Task<List<InventoryViewModel>> GetAllInventoryDataAtBL()
        {
            try
            {
                var iList = new List<InventoryViewModel>();
                using (var ctx = new BusinessContext())
                {
                    iList = await Task.Run(() => ctx.InventoryDBContext.ToList());
                    return iList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<InventoryViewModel> GetInventoryDataByIdAtBL(int Id)
        {
            try
            {
                var iList = new InventoryViewModel();
                using (var ctx = new BusinessContext())
                {
                    iList = await Task.Run(() => ctx.InventoryDBContext.FirstOrDefault(x => x.Id == Id));
                }
                return iList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SaveDataToInventoryAtBL(InventoryViewModel inventory)
        {
            try
            {
                using (var ctx = new BusinessContext())
                {
                    ctx.InventoryDBContext.Add(new InventoryViewModel()
                    {
                        Name = inventory.Name,
                        Description = inventory.Description,
                        Price = inventory.Price
                    });

                    await ctx.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateInventoryDataAtBL(InventoryViewModel inventory)
        {
            try
            {
                using (var ctx = new BusinessContext())
                {
                    var existingInvetoryData = ctx.InventoryDBContext.FirstOrDefault(x => x.Id == inventory.Id);
                    if (existingInvetoryData != null)
                    {
                        existingInvetoryData.Name = inventory.Name;
                        existingInvetoryData.Description = inventory.Description;
                        existingInvetoryData.Price = inventory.Price;

                        await ctx.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteInventoryDataAtBL(int Id)
        {
            try
            {
                using (var ctx = new BusinessContext())
                {
                    var existingRecord = ctx.InventoryDBContext.FirstOrDefault(x => x.Id == Id);
                    if (existingRecord != null)
                    {
                        ctx.InventoryDBContext.Remove(existingRecord);
                        await ctx.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}