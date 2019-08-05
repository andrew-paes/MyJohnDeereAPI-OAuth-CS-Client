using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class EquipmentType : Resource
    {
        [DataMember]
        public string name { get; set; }
        
        [DataMember]
        public string guid { get; set; }
        
        [DataMember]
        public EquipmentModels equipmentModels { get; set; }
        
        [DataMember]
        public string category { get; set; }
        
        [DataMember]
        public Creators creators { get; set; }
        
        [DataMember]
        public bool? certified { get; set; }
        
        [DataMember]
        public string marketSegment { get; set; }
    }
}