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
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class SComponent
    {
        public int Id { get; set; }

        [Required]
        public string ComponentName { get; set; }

        [ForeignKey("ComponentId")]
        public virtual List<GoodComponent> GoodComponent { get; set; }

        [ForeignKey("ComponentId")]
        public virtual List<SStockComponent> SStockComponent { get; set; }
    }
}
