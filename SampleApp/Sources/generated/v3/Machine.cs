using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Machine : Equipment
    {
        [DataMember]
        public string visualizationCategory { get; set; }
        
        [DataMember]
        public MachineCategories machineCategories { get; set; }
        
        [DataMember]
        public RdaValidation rdaValidationResult { get; set; }
        
        [DataMember]
        public MachineCategory category { get; set; }
        
        [DataMember]
        public MachineCategory make { get; set; }
        
        [DataMember]
        public MachineCategory model { get; set; }
        
        [DataMember]
        public MachineCategory detailMachineCode { get; set; }
        
        [DataMember]
        public int? categoryKey { get; set; }
        
        [DataMember]
        public string productKey { get; set; }
        
        [DataMember]
        public string engineSerialNumber { get; set; }
        
        [DataMember]
        public string telematicsState { get; set; }
        
        [DataMember]
        public List<MachineCapability> capabilities { get; set; }
        
        [DataMember]
        public Organization owningOrganization { get; set; }
        
        [DataMember]
        public Terminals terminals { get; set; }
        
        [DataMember]
        public Displays displays { get; set; }
        
        [DataMember]
        public string guid { get; set; }
        
        [DataMember]
        public Offsets offsets { get; set; }
        
        [DataMember]
        public ReportedLocation currentLocation { get; set; }
        
        [DataMember]
        public DeviceStateReports deviceStateReports { get; set; }
        
        [DataMember]
        public EngineHoursCollection engineHoursCollection { get; set; }
        
        [DataMember]
        public LocationHistory locationHistory { get; set; }
        
        [DataMember]
        public Alerts alerts { get; set; }
        
        [DataMember]
        public DistanceTraveled lastKnownDistanceTraveled { get; set; }
        
        [DataMember]
        public MachineGroups machineGroups { get; set; }
        
        [DataMember]
        public string isoName { get; set; }
        
        [DataMember]
        public string modelYear { get; set; }
        
        [DataMember]
        public string contributionDefinitionId { get; set; }
        
        [DataMember]
        public string externalId { get; set; }
        
        [DataMember]
        public bool? telematicsCapable { get; set; }
    }
}