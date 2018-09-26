using System;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Organization : Resource
    {
        [DataMember]
        public string name;
        [DataMember]
        public string type;
        [DataMember]
        public string accountId;
        [DataMember]
        public Boolean member;

    }
}
