using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    class Resource
    {
         [DataMember]
         internal List<Link> links;
         [DataMember]
         internal String id;
    }
}
