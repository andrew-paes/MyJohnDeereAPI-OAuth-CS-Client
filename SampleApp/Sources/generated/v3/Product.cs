using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public string guid { get; set; }
        
        [DataMember]
        public string productType { get; set; }
        
        [DataMember]
        public string name { get; set; }
        
        [DataMember]
        public string brand { get; set; }
        
        [DataMember]
        public bool? tankMix { get; set; }
        
        [DataMember]
        public EventMeasurement rate { get; set; }
        
        [DataMember]
        public Component carrier { get; set; }
        
        [DataMember]
        public List<Component> components { get; set; }
        
        [DataMember]
        public string agencyRegistrationNumber { get; set; }
    }
}