using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class EventMeasurement
    {
        [DataMember] 
        public double? value { get; set; }
        
        [DataMember]
        public string unitId { get; set; }
    }
}