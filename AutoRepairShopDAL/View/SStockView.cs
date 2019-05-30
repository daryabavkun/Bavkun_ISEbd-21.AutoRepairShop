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
    public class SStockView
    {
        [DataMember]
        public int Id { get; set; }
        [DisplayName("Название склада")]
        [DataMember]
        public string StockName { get; set; }
        [DataMember]
        public List<SStockComponentView> StockComponent { get; set; }
    }
}
