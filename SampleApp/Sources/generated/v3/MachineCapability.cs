using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class MachineCapability : Resource
    {
        [DataMember]
        public string type { get; set; }
        
        [DataMember]
        public bool capable { get; set; }
        
        [DataMember]
        public string availability { get; set; }
    }
}