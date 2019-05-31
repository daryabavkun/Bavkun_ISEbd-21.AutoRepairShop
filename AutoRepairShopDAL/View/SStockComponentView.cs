using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AutoRepairShopDAL.View
{
    [DataContract]
    public class SStockComponentView
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StockId { get; set; }
        [DataMember]
        public int ComponentId { get; set; }
        [DisplayName("Название компонента")]
        [DataMember]
        public string ComponentName { get; set; }
        [DisplayName("Количество")]
        [DataMember]
        public int Count { get; set; }
    }
}
