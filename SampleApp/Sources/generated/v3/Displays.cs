using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Displays : Resource
    {
        [DataMember]
        public int? total { get; set; }
        
        [DataMember]
        public List<Display> displaies { get; set; }
    }
}