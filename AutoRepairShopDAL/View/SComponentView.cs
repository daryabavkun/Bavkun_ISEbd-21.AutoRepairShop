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
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class SComponentView
    {
        [DataMember]
        public int Id { get; set; }
        [DisplayName("Название компонента")]
        [DataMember]
        public string ComponentName { get; set; }
    }
}
