using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    class Organization : Resource
    {
    [DataMember] internal string name;
    [DataMember] internal string type;
    [DataMember] internal string accountId;
    [DataMember] internal Boolean member;

    }
}
