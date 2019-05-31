using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AutoRepairShopDAL.View
{
    [DataContract]
    public class SOrderView
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DisplayName("ФИО Клиента")]
        [DataMember]
        public string ClientFIO { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DisplayName("Изделие")]
        [DataMember]
        public string ProductName { get; set; }
        [DisplayName("Количество")]
        [DataMember]
        public int? ImplementerId { get; set; }
        [DisplayName("Имя сотрудника")]
        [DataMember]
        public string ImplementerName { get; set; }
        [DisplayName("Количество")]
        [DataMember]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        [DataMember]
        public decimal Sum { get; set; }
        [DisplayName("Статус")]
        [DataMember]
        public string Status { get; set; }
        [DisplayName("Дата создания")]
        [DataMember]
        public string DateCreate { get; set; }
        [DisplayName("Дата выполнения")]
        [DataMember]
        public string DateImplement { get; set; }
    }
}
