﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShopDAL.View
{
    public class SClientOrders
    {
        public string ClientName { get; set; }
        public string DateCreate { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
    }
}
