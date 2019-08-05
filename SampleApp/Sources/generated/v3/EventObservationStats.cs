using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class EventObservationStats
    {
        [DataMember]
        public EventObservation firstObservation { get; set; }
        
        [DataMember]
        public EventObservation lastObservation { get; set; }
        
        [DataMember]
        public EventObservation predominantObservation { get; set; }
        
        [DataMember]
        public EventMeasurement areaRecorded { get; set; }
    }
}