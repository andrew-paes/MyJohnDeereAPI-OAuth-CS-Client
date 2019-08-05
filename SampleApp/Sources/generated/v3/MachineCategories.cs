using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class MachineCategories : Resource
    {
        [DataMember]
        public int? total { get; set; }
        
        [DataMember]
        public List<MachineCategory> machineCategories { get; set; }
    }
}