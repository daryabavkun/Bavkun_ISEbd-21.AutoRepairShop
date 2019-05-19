using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;using AutoRepairShop;

namespace AutoRepairShopServiceImplementDataBase
{
    public class AutoRepairShopDbContext : DbContext
    {
        public AutoRepairShopDbContext() : base("AbstractDatabase")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied =
           System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<SClient> Clients { get; set; }
        public virtual DbSet<SComponent> Components { get; set; }
        public virtual DbSet<SOrder> Orders { get; set; }
        public virtual DbSet<Good> Products { get; set; }
        public virtual DbSet<GoodComponent> ProductComponents { get; set; }
        public virtual DbSet<SStock> Stocks { get; set; }
        public virtual DbSet<SStockComponent> StockComponents { get; set; }
    }
}
