using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShop
{
    public class SStockComponent
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
    }
}
