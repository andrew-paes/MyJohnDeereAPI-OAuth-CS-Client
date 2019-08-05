using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class EngineHours : Resource
    {
        [DataMember]
        public AbstractMeasurement reading { get; set; }
        
        [DataMember]
        public string reportTime { get; set; }
        
        [DataMember]
        public string source { get; set; }
    }
}