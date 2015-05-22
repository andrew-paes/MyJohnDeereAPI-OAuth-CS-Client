using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    class Link
    {
        [DataMember]
        internal string rel;
        [DataMember]
        internal string uri;
        [DataMember]
        internal String followable;
    }
}
