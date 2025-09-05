using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using TqkLibrary.Gologin.Api.Enums;

namespace TqkLibrary.Gologin.Api.DataClasses
{
    public class WebRTC
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("mode")]
        public WebRTCMode? Mode { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("customize")]
        public bool? Customize { get; set; }

        [JsonProperty("localIpMasking")]
        public bool? LocalIpMasking { get; set; }

        [JsonProperty("fillBasedOnIp")]
        public bool? FillBasedOnIp { get; set; }

        [JsonProperty("publicIp")]
        public string PublicIp { get; set; }

        [JsonProperty("localIps")]
        public List<string> LocalIps { get; set; }

        public override string ToString()
        {
            return $"Mode: {Mode}, Enabled: {Enabled}, Customize: {Customize}, LocalIpMasking: {LocalIpMasking}, FillBasedOnIp: {FillBasedOnIp}, PublicIp: {PublicIp}";
        }
    }

}
