using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class Boundary : Resource
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string sourceType { get; set; }

        [DataMember]
        public string modifiedTime { get; set; }

        [DataMember]
        public MeasurementAsDouble area { get; set; }

        [DataMember]
        public MeasurementAsDouble workableArea { get; set; }

        [DataMember]
        public List<Polygon> multipolygons { get; set; }
    }

    [DataContract]
    public class Polygon
    {
        [DataMember]
        public List<Ring> rings { get; set; }
    }

    [DataContract]
    public class Ring
    {
        [DataMember]
        public string type { get; set; }

        [DataMember]
        public Boolean passable { get; set; }

        [DataMember]
        public List<Point> points { get; set; }
    }

    [DataContract]
    public class Point : Resource
    {
        [DataMember]
        public double lat { get; set; }

        [DataMember]
        public double lon { get; set; }

        [DataMember]
        public AbstractMeasurement altitude { get; set; }
    }

    [DataContract]
    public class MeasurementAsDouble : AbstractMeasurement
    {
        [DataMember]
        public double valueAsDouble { get; set; }
    }

    [DataContract]
    public class AbstractMeasurement : Resource
    {
        [DataMember]
        public string vrDomainId { get; set; }

        [DataMember]
        public string unit { get; set; }
    }
}
