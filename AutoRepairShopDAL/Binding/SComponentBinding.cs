using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShopDAL.Binding
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class SComponentBinding
    {
        public int Id { get; set; }
        public string ComponentName { get; set; }
    }
}
