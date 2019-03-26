using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShop
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class SComponent
    {
        public int Id { get; set; }
        public string ComponentName { get; set; }
    }
}
