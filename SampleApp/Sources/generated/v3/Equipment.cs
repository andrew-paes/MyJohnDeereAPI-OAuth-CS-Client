using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Equipment : Resource
    {
        [DataMember]
        public string vin { get; set; }
        
        [DataMember]
        public string name { get; set; }
        
        [DataMember]
        public EquipmentMake equipmentMake { get; set; }
        
        [DataMember]
        public EquipmentType equipmentType { get; set; }
        
        [DataMember]
        public EquipmentApexType equipmentApexType { get; set; }
        
        [DataMember]
        public EquipmentModel equipmentModel { get; set; }
        
        [DataMember]
        public EquipmentIcon icon { get; set; }
        
        [DataMember]
        public Vins vins { get; set; }
    }
}