using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class EquipmentApexType : Resource
    {
        [DataMember]
        public string name { get; set; }
        
        [DataMember]
        public string guid { get; set; }
        
        [DataMember]
        public EquipmentModels equipmentModels { get; set; }
        
        [DataMember]
        public string category { get; set; }
    }
}