﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class User : Resource
    {
        [DataMember] internal String accountName;
        [DataMember] internal String givenName;
        [DataMember] internal String familyName;
        [DataMember] internal String userType;
        [DataMember] internal String company;
    }
}
