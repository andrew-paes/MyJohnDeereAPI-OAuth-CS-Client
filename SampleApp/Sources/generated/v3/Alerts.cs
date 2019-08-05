using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Alerts : Resource
    {
        [DataMember]
        public int? total { get; set; }
        
        [DataMember]
        public List<Alert> alerts { get; set; }
    }
}