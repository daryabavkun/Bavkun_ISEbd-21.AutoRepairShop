using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShop
{
    /// <summary>
    /// Хранилиище компонентов в магазине
    /// </summary>
    public class SStock
    {        
        public int Id { get; set; }

        [Required]
        public string StockName { get; set; }

        [ForeignKey("StockId")]
        public virtual List<SStockComponent> SStockComponent { get; set; }
    }
}
