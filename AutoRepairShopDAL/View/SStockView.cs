using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AutoRepairShopDAL.View
{
    public class SStockView
    {
        public int Id { get; set; }
        [DisplayName("Название склада")]
        public string StockName { get; set; }
        public List<SStockComponentView> StockComponents { get; set; }
    }
}
