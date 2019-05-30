using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShop
{
    /// <summary>
    /// Заказ клиента
    /// </summary>
    public class SOrder
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int? ImplementerId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public SOrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual SClient Client { get; set; }
        public virtual Good Product { get; set; }
        public virtual Implementer Implementer { get; set; }
    }
}
