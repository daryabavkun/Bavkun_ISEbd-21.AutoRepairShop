using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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
