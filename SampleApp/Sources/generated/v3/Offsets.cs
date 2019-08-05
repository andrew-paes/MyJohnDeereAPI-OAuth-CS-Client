using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Offsets : Resource
    {
        [DataMember]
        public List<VariableRepresentationValue> variableRepresentationValues { get; set; }
        
        [DataMember]
        public List<DefinedTypeRepresentationValue> definedTypeRepresentationValues { get; set; }
    }
}