using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class FieldOperationMeasurement
    {
        [DataMember]
        public string measurementName { get; set; }
        
        [DataMember]
        public string measurementCategory { get; set; }
        
        [DataMember]
        public EventMeasurement area { get; set; }
        
        [DataMember]
        public EventMeasurement yield { get; set; }
        
        [DataMember]
        public EventMeasurement averageYield { get; set; }
        
        [DataMember]
        public EventMeasurement averageMoisture { get; set; }
        
        [DataMember]
        public EventMeasurement wetMass { get; set; }
        
        [DataMember]
        public EventMeasurement averageWetMass { get; set; }
        
        [DataMember]
        public EventMeasurement harvestLabAccumulatedWetMass { get; set; }
        
        [DataMember]
        public EventMeasurement averageSpeed { get; set; }
        
        [DataMember]
        public EventMeasurement totalMaterial { get; set; }
        
        [DataMember]
        public EventMeasurement averageMaterial { get; set; }
        
        [DataMember]
        public EventMeasurement averageDepth { get; set; }
        
        [DataMember]
        public EventMeasurement averagePressure { get; set; }
        
        [DataMember]
        public EventMeasurement averageTrash { get; set; } 
        
        [DataMember]
        public EventMeasurement averageAcidDetergentFiber { get; set; }
        
        [DataMember]
        public EventMeasurement averageNeutralDetergentFiber { get; set; }
        
        [DataMember]
        public EventMeasurement averageStarch { get; set; }
        
        [DataMember]
        public EventMeasurement averageCrudeProtein { get; set; }
        
        [DataMember]
        public EventMeasurement averageSugar { get; set; }
        
        [DataMember]
        public EventMeasurement maxAcidDetergentFiber { get; set; }
        
        [DataMember]
        public EventMeasurement maxNeutralDetergentFiber { get; set; }
        
        [DataMember]
        public EventMeasurement maxStarch { get; set; }
        
        [DataMember]
        public EventMeasurement maxCrudeProtein { get; set; }
        
        [DataMember]
        public EventMeasurement maxSugar { get; set; }
        
        [DataMember]
        public EventMeasurementStats elevation { get; set; }
        
        [DataMember]
        public EventMeasurementStats fuelRate { get; set; }
        
        [DataMember]
        public EventMeasurementStats applicationHeight { get; set; }
        
        [DataMember]
        public EventMeasurementStats windSpeed { get; set; }
        
        [DataMember]
        public EventMeasurementStats temperature { get; set; }
        
        [DataMember]
        public EventMeasurementStats temperatureDifference { get; set; }
        
        [DataMember]
        public EventMeasurementStats humidity { get; set; }
        
        [DataMember]
        public EventMeasurementStats windDirection { get; set; }
        
        [DataMember]
        public EventMeasurementStats skyCondition { get; set; }
        
        [DataMember]
        public EventMeasurementStats soilMoisture { get; set; }
        
        [DataMember]
        public EventMeasurementStats rate { get; set; }
        
        [DataMember]
        public EventMeasurementStats pressure { get; set; }
        
        [DataMember]
        public EventMeasurementStats depth { get; set; }
        
        [DataMember]
        public EventMeasurementStats dosing { get; set; }
        
        [DataMember]
        public EventMeasurementStats cutLength { get; set; }
        
        [DataMember]
        public EventMeasurementStats gaugeWheelMargin { get; set; }
        
        [DataMember]
        public EventMeasurementStats downforce { get; set; }
        
        [DataMember]
        public EventMeasurementStats groundContact { get; set; }
        
        [DataMember]
        public EventMeasurementStats rideQuality { get; set; }
        
        [DataMember]
        public EventMeasurementStats seedSpacingVariation { get; set; }
        
        [DataMember]
        public EventMeasurementStats singulation { get; set; }
        
        [DataMember]
        public EventMeasurementStats doubles { get; set; }
        
        [DataMember]
        public EventMeasurementStats skips { get; set; }
        
        [DataMember]
        public EventMeasurementStats yieldVolume { get; set; }
        
        [DataMember]
        public EventMeasurementStats quality { get; set; }
        
        [DataMember]
        public List<VarietyTotal> varietyTotals { get; set; }
        
        [DataMember]
        public List<ProductTotal> productTotals { get; set; }
    }
}