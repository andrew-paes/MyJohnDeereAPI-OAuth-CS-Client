using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Version
    {
        [DataMember]
        public string number { get; set; }
        
        [DataMember]
        public string type { get; set; }
    }
}