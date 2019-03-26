using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShopDAL.View
{
    public class SOrderView
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [DisplayName("ФИО Клиента")]
        public string ClientFIO { get; set; }
        public int ProductId { get; set; }
        [DisplayName("Изделие")]
        public string ProductName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DisplayName("Статус")]
        public string Status { get; set; }
        [DisplayName("Дата создания")]
        public string DateCreate { get; set; }
        [DisplayName("Дата выполнения")]
        public string DateImplement { get; set; }
    }
}
