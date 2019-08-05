using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class VariableRepresentationValue : Resource
    {
        [DataMember]
        public AbstractMeasurement variable { get; set; }
        
        [DataMember]
        public VariableRepresentation variableRepresentation { get; set; }
    }
}