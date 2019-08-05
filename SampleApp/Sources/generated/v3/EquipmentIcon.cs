using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class EquipmentIcon : Resource
    {
        [DataMember]
        public string name { get; set; }
        
        [DataMember]
        public IconStyle iconStyle { get; set; }
    }
}