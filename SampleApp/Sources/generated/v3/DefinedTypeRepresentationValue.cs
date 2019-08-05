using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class DefinedTypeRepresentationValue : Resource
    {
        [DataMember]
        public AbstractMeasurement value { get; set; }
        
        [DataMember]
        public DefinedTypeRepresentation definedTypeRepresentation { get; set; }
    }
}