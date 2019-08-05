using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Layer : Resource
    {
        [DataMember]
        public string layerName { get; set; }
        
        [DataMember]
        public string layerCategory { get; set; }
        
        [DataMember]
        public string repSystemId { get; set; }
     
        [DataMember]
        public List<EventStats> operationValues { get; set; }

        [DataMember]
        public List<ProductDetails> products { get; set; }
    }
}