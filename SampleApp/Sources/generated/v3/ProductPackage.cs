using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class ProductPackage : Resource
    {        
        [DataMember]
        public string displayName { get; set; }
        
        [DataMember]
        public string notificationName { get; set; }
        
        [DataMember]
        public string serialNumber { get; set; }
        
        [DataMember]
        public string startDate { get; set; }
        
        [DataMember]
        public string expirationDate { get; set; }
        
        [DataMember]
        public double? maxEngineHours { get; set; }
        
        [DataMember]
        public string state { get; set; }
        
        [DataMember]
        public string type { get; set; }
    }
}