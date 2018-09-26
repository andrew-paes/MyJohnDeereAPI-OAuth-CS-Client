using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace SampleApp.Sources.generated.v3
{
    [DataContract]
    public class File : Resource
    {

    [DataMember]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string name;

    [DataMember]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string type;

    [DataMember]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string createdTime;
    [DataMember]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string modifiedTime;
    [DataMember]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public long nativeSize;
    [DataMember]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string source;
    [DataMember]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Boolean transferPending;
    [DataMember]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string visibleViaShare;
    [DataMember]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Boolean shared;
    [DataMember]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string status;
    [DataMember]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string invalidFileReasonText;
    [DataMember]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public String archived;
    [DataMember]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public String success;
    }
}
