using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class RdaValidation
    {
        [DataMember]
        public List<Link> links { get; set; }
        
        [DataMember]
        public string uri { get; set; }
        
        [DataMember]
        public long? id { get; set; }
        
        [DataMember]
        public bool success { get; set; }
        
        [DataMember]
        public string rdaSessionStatus { get; set; }
    }
}