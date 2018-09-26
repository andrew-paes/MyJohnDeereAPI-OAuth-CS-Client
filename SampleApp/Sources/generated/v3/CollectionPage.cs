using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class CollectionPage<T> {
        [DataMember]
        public int totalSize;
        [DataMember]
        public Uri nextPage;
        [DataMember]
        public Uri prevPage;
        [DataMember]
        public Uri self;
        [DataMember]
        public List<T> page;
    }
}
