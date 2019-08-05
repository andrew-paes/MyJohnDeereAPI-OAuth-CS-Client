using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class EventStats
    {
        [DataMember]
        public EventMeasurementStats measurementStats { get; set; }
        
        [DataMember]
        public EventObservationStats observationStats { get; set; }
    }
}