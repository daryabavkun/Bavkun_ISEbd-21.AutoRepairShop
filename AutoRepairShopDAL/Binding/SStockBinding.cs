using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AutoRepairShopDAL.Binding
{
    [DataContract]
    public class SStockBinding
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string StockName { get; set; }
    }
}
