using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class BreadcrumbConfiguration : Resource
    {
        [DataMember]
        public bool breadcrumbEnabled { get; set; }
        
        [DataMember]
        public AbstractMeasurement breadcrumbTimeInterval { get; set; }
        
        [DataMember]
        public AbstractMeasurement minimumDistance { get; set; }
        
        [DataMember]
        public AbstractMeasurement headingTrigger { get; set; }
        
        [DataMember]
        public AbstractMeasurement headingTriggerDelay { get; set; }
        
        [DataMember]
        public bool? machineStateTriggerEnabled { get; set; }
        
        [DataMember]
        public bool? loggingFuelLevel { get; set; }
        
        [DataMember]
        public bool? loggingMachineState { get; set; }
        
        [DataMember]
        public AbstractMeasurement maxAcceptableAgeOfGpsFix { get; set;}
        
        [DataMember]
        public AbstractMeasurement distanceFromLastCourseThreshold { get; set; }
        
        [DataMember]
        public AbstractMeasurement minElapsedTimeSinceLastBreadcrumb { get; set; }
        
        [DataMember]
        public AbstractMeasurement locationHistoryReportPeriod { get; set; }
        
        [DataMember]
        public bool? loggingCellular { get; set; }
        
        [DataMember]
        public bool? loggingRssi { get; set; }
        
        [DataMember]
        public long? configurationTimestamp { get; set; }
        
        [DataMember]
        public bool? currentConfiguration { get; set; }
    }
}