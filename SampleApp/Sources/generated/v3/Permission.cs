using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Permission : Resource
    {
        [DataMember]
        public int? permissionId { get; set; }
        
        [DataMember]
        public int? accessLevel { get; set; }
        
        [DataMember]
        public string type { get; set; }
        
        [DataMember]
        public string status { get; set; }
        
        [DataMember]
        public string permissionGroup { get; set; }
    }
}