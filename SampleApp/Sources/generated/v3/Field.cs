using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Field : Resource
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public Clients clients { get; set; }

        [DataMember]
        public Farms farms { get; set; }

        [DataMember]
        public List<Boundary> boundaries { get; set; }
    }

    [DataContract]
    public class Clients
    {
        [DataMember]
        public List<Client> clients { get; set; }
    }

    [DataContract]
    public class Client : Resource
    {
        [DataMember]
        public string name { get; set; }
    }

    [DataContract]
    public class Farms
    {
        [DataMember]
        public List<Farm> farms { get; set; }
    }

    [DataContract]
    public class Farm : Resource
    {
        [DataMember]
        public string name { get; set; }
    }
}
