using System.Runtime.Serialization;

namespace AutoRepairShopDAL.View
{
    [DataContract]
    public class ImplementerView
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ImplementerFIO { get; set; }
    }
}
