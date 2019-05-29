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
    public class GoodView
    {
        [DataMember]
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        [DataMember]
        public string ProductName { get; set; }
        [DisplayName("Цена")]
        [DataMember]
        public decimal Price { get; set; }
        public List<GoodComponentView> ProductComponent { get; set; }
    }
}
