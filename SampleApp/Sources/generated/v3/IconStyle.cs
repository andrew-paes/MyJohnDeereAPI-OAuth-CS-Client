using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class IconStyle
    {
        [DataMember]
        public string primaryColor { get; set; }
        
        [DataMember]
        public string secondaryColor { get; set; }
        
        [DataMember]
        public string stripeColor { get; set; }
    }
}