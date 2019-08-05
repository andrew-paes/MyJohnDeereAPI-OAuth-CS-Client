using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Alert : Resource
    {
        [DataMember]
        public string time { get; set; }
        
        [DataMember]
        public Point location { get; set; }
        
        [DataMember]
        public string color { get; set; }
        
        [DataMember]
        public string severity { get; set; }
        
        [DataMember]
        public string acknowledgementStatus { get; set; }
        
        [DataMember]
        public string acknowledgementTime { get; set; }
        
        [DataMember]
        public bool? ignored { get; set; }
        
        [DataMember]
        public bool? invisible { get; set; }
        
        [DataMember]
        public Machine machine { get; set; }
    }
}