using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class FieldOperationMachine : Resource
    {
        [DataMember]
        public string name { get; set; }
        
        [DataMember]
        public string vin { get; set; }
        
        [DataMember]
        public string guid { get; set; }

        [DataMember]
        public Machine machine { get; set; }

        [DataMember]
        public string make { get; set; }
        
        [DataMember]
        public int? modelYear { get; set; }
        
        [DataMember]
        public string model { get; set; }
        
        [DataMember]
        public string adaptMachineType { get; set; }
        
        [DataMember]
        public long? beginEngineHours { get; set; }
        
        [DataMember]
        public long? endEngineHours { get; set; }
        
        [DataMember]
        public string beginTime { get; set; }
        
        [DataMember]
        public string endTime { get; set; }
        
        [DataMember]
        public string modifiedTime { get; set; }
        
        [DataMember]
        public string cropName { get; set; }

        [DataMember]
        public Product products { get; set; }

        [DataMember]
        public List<Layer> layers { get; set; }

        [DataMember]
        public List<Operator> operators { get; set; }
    }
}