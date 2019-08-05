using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Terminal : Resource
    {
        [DataMember]
        public string serialNumber { get; set; }
        
        [DataMember]
        public string type { get; set; }
        
        [DataMember]
        public string hardwareType { get; set; }
        
        [DataMember]
        public Version version { get; set; }
        
        [DataMember]
        public string comarOrderNumber { get; set; }
        
        [DataMember]
        public string activeTransferDate { get; set; }
        
        [DataMember]
        public string registrationDate { get; set; }
        
        [DataMember]
        public string registrationStatus { get; set; }

        [DataMember] 
        public List<BreadcrumbConfiguration> breadcrumbConfigurations { get; set; }
                
        [DataMember]
        public Licenses licenses { get; set; }
        
        [DataMember]
        public List<ProductPackage> productPackages { get; set; }
        
        [DataMember]
        public Subscriptions subscriptions { get; set; }
        
        [DataMember]
        public DeviceStateReport lastKnownCallHistory { get; set; }
        
        [DataMember]
        public Machine associatedMachine { get; set; }
        
        [DataMember]
        public List<Display> connectedDisplays { get; set; }
        
        [DataMember]
        public Organization owningOrganization { get; set; }
        
        [DataMember]
        public CommunicationModules communicationModules { get; set; }
        
        [DataMember]
        public bool? deactivationIndicator { get; set; }
        
        [DataMember]
        public Invitation invitation { get; set; }
        
        [DataMember]
        public bool? breadcrumbEnabled { get; set; }
        
        [DataMember]
        public string breadcrumbConfigurationDate { get; set; }
        
        [DataMember]
        public bool? wdtEnabled { get; set; }
        
        [DataMember]
        public bool? managed { get; set; }
    }
}