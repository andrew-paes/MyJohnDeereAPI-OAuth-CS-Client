using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Display : Resource
    {
        [DataMember]
        public string serialNumber { get; set; }
        
        [DataMember]
        public string type { get; set; }
        
        [DataMember]
        public Version firmwareVersion { get; set; }
        
        [DataMember]
        public int? screenHeight { get; set; }
        
        [DataMember]
        public int? screenWidth { get; set; }
        
        [DataMember]
        public DisplayApplicationParameters displayApplicationParameters { get; set; }
        
        [DataMember]
        public Organization organization { get; set; }
    }
}