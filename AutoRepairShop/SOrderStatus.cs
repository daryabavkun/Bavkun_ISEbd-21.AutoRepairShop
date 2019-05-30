﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRepairShop;

namespace AutoRepairShop
{
    /// <summary>
    /// Статус заказа
    /// </summary>
    public enum SOrderStatus
    {
        Принят = 0,
        Выполняется = 1,
        Готов = 2,
        Оплачен = 3,
        НедостаточноРесурсов = 4
    }
}
