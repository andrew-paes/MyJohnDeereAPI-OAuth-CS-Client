using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class DisplayApplicationParameter : Resource
    {
        [DataMember]
        public string name { get; set; }
        
        [DataMember]
        public string type { get; set; }
    }
}