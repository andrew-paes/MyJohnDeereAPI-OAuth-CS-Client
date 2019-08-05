using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class EquipmentMake : Resource
    {
        [DataMember]
        public string name { get; set; }
        
        [DataMember]
        public EquipmentTypes equipmentTypes { get; set; }
        
        [DataMember]
        public EquipmentApexTypes equipmentApexTypes { get; set; }
        
        [DataMember]
        public Creators creators { get; set; }
        
        [DataMember]
        public bool? certified { get; set; }
    }
}