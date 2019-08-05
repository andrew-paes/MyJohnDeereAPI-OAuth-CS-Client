using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class ProductTotal
    {
        [DataMember] public string productId{ get; set; }
        
        [DataMember] public string name{ get; set; }
        
        [DataMember] public string brand{ get; set; }
        
        [DataMember] public bool? carrier{ get; set; }
        
        [DataMember] public EventMeasurement totalMaterial{ get; set; }
        
        [DataMember] public EventMeasurement averageMaterial{ get; set; }
        
        [DataMember] public EventMeasurementStats elevation{ get; set; }
        
        [DataMember] public EventMeasurementStats fuelRate{ get; set; }
        
        [DataMember] public EventMeasurementStats applicationHeight{ get; set; }
        
        [DataMember] public EventMeasurementStats windSpeed{ get; set; }
        
        [DataMember] public EventObservationStats windDirection{ get; set; }
        
        [DataMember] public EventMeasurementStats rate{ get; set; }
        
        [DataMember] public EventMeasurementStats pressure{ get; set; }
        
        [DataMember] public EventMeasurementStats depth{ get; set; }
        
        [DataMember] public EventMeasurementStats dosing{ get; set; }
        
        [DataMember] public EventMeasurementStats cutLength{ get; set; }
        
        [DataMember] public EventMeasurementStats gaugeWheelMargin{ get; set; }
        
        [DataMember] public EventMeasurementStats downforce{ get; set; }
        
        [DataMember] public EventMeasurementStats groundContact{ get; set; }
        
        [DataMember] public EventMeasurementStats seedSpacingVariation{ get; set; }
        
        [DataMember] public EventMeasurementStats rideQuality{ get; set; }
        
    }
}