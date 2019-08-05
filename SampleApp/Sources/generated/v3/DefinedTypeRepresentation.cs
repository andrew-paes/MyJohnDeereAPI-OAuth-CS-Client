using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class DefinedTypeRepresentation : Resource
    {
        [DataMember]
        public List<AbstractMeasurement> enumeratedValues { get; set; }
    }
}