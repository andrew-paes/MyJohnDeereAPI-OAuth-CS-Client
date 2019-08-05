using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class ReportedLocation : Resource
    {
        [DataMember]
        public Point point { get; set; }
        
        [DataMember]
        public string eventTimestamp { get; set; }
        
        [DataMember]
        public string gpsFixTimestamp { get; set; }
    }
}