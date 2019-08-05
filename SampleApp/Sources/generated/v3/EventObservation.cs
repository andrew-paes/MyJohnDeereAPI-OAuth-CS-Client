using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class EventObservation
    {
        [DataMember]
        public string value { get; set; }
    }
}