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
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class Good
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }

        [ForeignKey("ProductId")]
        public virtual List<SOrder> SOrders { get; set; }
    }
}
