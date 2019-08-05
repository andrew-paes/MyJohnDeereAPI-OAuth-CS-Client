using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class DistanceTraveled : Resource
    {
        [DataMember]
        public string startDate { get; set; }
        
        [DataMember]
        public string endDate { get; set; }
        
        [DataMember]
        public string lastReportedTime { get; set; }
        
        [DataMember]
        public double? totalDistance { get; set; }
        
        [DataMember]
        public double? spanDistance { get; set; }
    }
}