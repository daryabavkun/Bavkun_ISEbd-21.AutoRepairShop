using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AutoRepairShopDAL.View
{
    [DataContract]
    public class SClientOrders
    {
        [DataMember]
        public string ClientName { get; set; }
        [DataMember]
        public string DateCreate { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
