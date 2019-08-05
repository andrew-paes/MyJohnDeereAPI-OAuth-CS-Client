using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Operator : Resource
    {
        [DataMember]
        public string name { get; set; }
        
        [DataMember]
        public string guid { get; set; }
        
        [DataMember]
        public string license { get; set; }
        
        [DataMember]
        public string uucUsername { get; set; }
        
        [DataMember]
        public string dateModified { get; set; }
    }
}