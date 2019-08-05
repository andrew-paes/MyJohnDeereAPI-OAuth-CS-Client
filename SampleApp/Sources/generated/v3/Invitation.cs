using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Invitation : Resource
    {
        [DataMember]
        public string receiversEmail { get; set; }
        
        [DataMember]
        public string type { get; set; }
        
        [DataMember]
        public string token { get; set; }
        
        [DataMember]
        public Organization sendersOrganization { get; set; }
        
        [DataMember]
        public string status { get; set; }
        
        [DataMember]
        public User sentByUser { get; set; }
        
        [DataMember]
        public List<string> assignedRoles { get; set; }
        
        [DataMember]
        public List<string> assignedPermissions { get; set; }
        
        [DataMember]
        public ResourceShare owningShare { get; set; }
        
        [DataMember]
        public ResourceShare contactShare { get; set; }
        
        [DataMember]
        public List<Organization> customers { get; set; }
        
        [DataMember]
        public bool? hasAccessToAllCustomers { get; set; }
    }
}