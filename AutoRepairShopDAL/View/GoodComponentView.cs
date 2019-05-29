﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AutoRepairShopDAL.View
{
    [DataContract]
    public class GoodComponentView
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int ComponentId { get; set; }
        [DisplayName("Материал")]
        [DataMember]
        public string ComponentName { get; set; }
        [DisplayName("Количество")]
        [DataMember]
        public int Count { get; set; }
    }
}
