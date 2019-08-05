using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class VariableRepresentation : Resource
    {
        [DataMember]
        public string numberFormat { get; set; }
        
        [DataMember]
        public string unitOfMeasure { get; set; }
    }
}