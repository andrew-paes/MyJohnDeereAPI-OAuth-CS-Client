using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class ResourceShare : Resource
    {
        [DataMember]
        public string creator { get; set; }
        
        [DataMember]
        public long? dataControlPrintTimestamp { get; set; }
        
        [DataMember]
        public string resourceType { get; set; }
        
        [DataMember]
        public string resourceId { get; set; }
        
        [DataMember]
        public string sharedTime { get; set; }
        
        [DataMember]
        public Organization senderOrganization { get; set; }
        
        [DataMember]
        public Organization shareWithOrganization { get; set; }
        
        [DataMember]
        public List<string> shareWithEmails { get; set; }
        
        [DataMember]
        public string status { get; set; }
        
        [DataMember]
        public string token { get; set; }
        
        [DataMember]
        public string shareType { get; set; }
        
        [DataMember]
        public bool? thirdPartyShare { get; set; }
        
        [DataMember]
        public bool? partnerSetupComplete { get; set; }
        
        [DataMember]
        public List<Permission> permissions { get; set; }
        
        [DataMember]
        public string inheritedToken { get; set; }
        
        [DataMember]
        public bool? extendPartnerships { get; set; }
    }
}