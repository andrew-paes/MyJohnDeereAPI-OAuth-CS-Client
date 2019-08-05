using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Vin : Resource
    {
        [DataMember]
        public string type { get; set; }
        
        [DataMember]
        public string value { get; set; }
    }
}