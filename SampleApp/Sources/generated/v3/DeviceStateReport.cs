using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class DeviceStateReport : Resource
    {
        [DataMember]
        public string time { get; set; }
        
        [DataMember]
        public byte? gatewayType { get; set; }
        
        [DataMember]
        public Point location { get; set; }
        
        [DataMember]
        public AbstractMeasurement minRSSI { get; set; }
        
        [DataMember]
        public AbstractMeasurement maxRSSI { get; set; }
        
        [DataMember]
        public AbstractMeasurement averageRSSI { get; set; }
        
        [DataMember]
        public string gpsFixTimestamp { get; set; }
        
        [DataMember]
        public byte? engineState { get; set; }
        
        [DataMember]
        public byte? terminalPowerState { get; set; }
        
        [DataMember]
        public AbstractMeasurement batteryLevel { get; set; }
        
        [DataMember]
        public byte? cellModemState { get; set; }
        
        [DataMember]
        public byte? cellModemAntennaState { get; set; }
        
        [DataMember]
        public byte? gpsModemState { get; set; }
        
        [DataMember]
        public byte? gpsAntennaState { get; set; }
        
        [DataMember]
        public byte? network { get; set; }
        
        [DataMember]
        public byte? rssi { get; set; }
    }
}