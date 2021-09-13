using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventoryManagement.DataBaseLayer
{
    public class BusinessContext : DbContext
    {
        public BusinessContext() : base("name=LocalDBConnectionString")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<BusinessContext>());
        }
        public DbSet<InventoryViewModel> InventoryDBContext{ get; set; }
    }
}