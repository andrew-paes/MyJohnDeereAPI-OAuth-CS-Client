using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class EquipmentModel : Resource
    {
        [DataMember]
        public string name { get; set; }
        
        [DataMember]
        public string guid { get; set; }
        
        [DataMember]
        public Creators creators { get; set; }
        
        [DataMember]
        public bool? certified { get; set; }
        
        [DataMember]
        public string classification { get; set; }
    }
}