using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class EventMeasurementStats
    {
        [DataMember]
        public EventMeasurement averageValue { get; set; }
        
        [DataMember]
        public EventMeasurement totalValue { get; set; }
        
        [DataMember]
        public EventMeasurement minValue { get; set; }
        
        [DataMember]
        public EventMeasurement maxValue { get; set; }
        
        [DataMember]
        public EventMeasurement firstValue { get; set; }
        
        [DataMember]
        public EventMeasurement lastValue { get; set; }
        
        [DataMember]
        public EventMeasurement areaRecorded { get; set; }
    }
}