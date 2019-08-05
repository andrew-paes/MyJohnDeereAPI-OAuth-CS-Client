using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class FieldOperation : Resource
    {
        [DataMember]
        public string fieldOperationType { get; set; }
        
        [DataMember]
        public string adaptMachineType { get; set; }
        
        [DataMember]
        public string cropSeason { get; set; }
        
        [DataMember]
        public string modifiedTime { get; set; }
        
        [DataMember]
        public string startDate { get; set; }
        
        [DataMember]
        public string endDate { get; set; }
        
        [DataMember]
        public string cropName { get; set; }
     
        [DataMember]
        public Product product { get; set; }

        [DataMember]
        public List<FieldOperationMeasurement> measurementTypes { get; set; }

        [DataMember]
        public Client client { get; set; }
        
        [DataMember]
        public Farm farm { get; set; }
        
        [DataMember]
        public Field field { get; set; }
     
        [DataMember]
        public List<FieldOperationMachine> fieldOperationMachines { get; set; }

        [DataMember]
        public Point operationStartPoint { get; set; }
    }
}