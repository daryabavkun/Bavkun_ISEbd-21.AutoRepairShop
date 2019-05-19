using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRepairShop
{
    /// Клиент магазина
    /// </summary>
    public class SClient
    {
        public int Id { get; set; }
        [Required]
        public string ClientFIO { get; set; }
        [ForeignKey("ClientId")]
        public virtual List<SOrder> Orders { get; set; }
    }
}
