using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class CommunicationModule : Resource
    {
        [DataMember]
        public string serialNumber { get; set; }
        
        [DataMember]
        public string imei { get; set; }
        
        [DataMember]
        public string imsi { get; set; }
        
        [DataMember]
        public string iccid { get; set; }
        
        [DataMember]
        public string msisdn { get; set; }
        
        [DataMember]
        public string communicationModuleType { get; set; }
        
        [DataMember]
        public string serviceProvider { get; set; }
        
        [DataMember]
        public string state { get; set; }
        
        [DataMember]
        public string countryCallingCode { get; set; }
        
        [DataMember]
        public string mobileCountryCode { get; set; }
    }
}