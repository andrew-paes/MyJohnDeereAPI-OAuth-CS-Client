using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Resource
    {
        [DataMember]
        public List<Link> links;
        [DataMember]
        public String id;
        [DataMember]
        public String @type;
    }
}
