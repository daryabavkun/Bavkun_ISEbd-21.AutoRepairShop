using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AutoRepairShopDAL.View
{
    public class SStockComponentView
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int ComponentId { get; set; }
        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
