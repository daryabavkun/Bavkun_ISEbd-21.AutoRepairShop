using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AutoRepairShopDAL.Binding
{
    [DataContract]
    /// Клиент магазина
    /// </summary>
    public class SClientBinding
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ClientFIO { get; set; }
    }
}
