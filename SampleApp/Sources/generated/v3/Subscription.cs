using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Subscription : Resource
    {
        [DataMember]
        public string type { get; set; }
        
        [DataMember]
        public string startDate { get; set; }
        
        [DataMember]
        public string endDate { get; set; }
        
        [DataMember]
        public Terminal terminal { get; set; }
        
        [DataMember]
        public bool? enable { get; set; }
    }
}