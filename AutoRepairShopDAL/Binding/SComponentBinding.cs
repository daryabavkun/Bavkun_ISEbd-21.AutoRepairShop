using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AutoRepairShopDAL.Binding
{
    [DataContract]
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class SComponentBinding
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ComponentName { get; set; }
    }
}
