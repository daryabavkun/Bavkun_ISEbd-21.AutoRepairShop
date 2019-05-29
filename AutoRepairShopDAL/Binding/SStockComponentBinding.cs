using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AutoRepairShopDAL.Binding
{
    [DataContract]
    public class SStockComponentBinding
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StockId { get; set; }
        [DataMember]
        public int ComponentId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
