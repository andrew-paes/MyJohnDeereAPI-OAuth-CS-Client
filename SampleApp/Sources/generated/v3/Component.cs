using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Component
    {
        [DataMember]
        public string name { get; set; }
        
        [DataMember]
        public EventMeasurement rate { get; set; }
        
        [DataMember]
        public string guid { get; set; }
        
        [DataMember]
        public string agencyRegistrationNumber { get; set; }
    }
}