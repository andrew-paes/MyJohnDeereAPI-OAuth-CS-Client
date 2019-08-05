using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class CommunicationModules : Resource
    {
        [DataMember]
        public int? totals { get; set; }
        
        [DataMember]
        public List<CommunicationModule> communicationModules { get; set; }
    }
}