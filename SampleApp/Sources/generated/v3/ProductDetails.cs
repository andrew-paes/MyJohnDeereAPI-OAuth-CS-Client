using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class ProductDetails : Resource
    {
        [DataMember]
        public string name { get; set; }
        
        [DataMember]
        public string brand { get; set; }
        
        [DataMember]
        public string guid { get; set; }
        
        [DataMember]
        public List<EventStats> productValues { get; set; }
    }
}