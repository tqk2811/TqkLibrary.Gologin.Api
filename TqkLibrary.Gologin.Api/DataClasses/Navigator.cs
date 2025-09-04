using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api
{
    public class Navigator
    {
        [JsonProperty("userAgent")]
        public string? UserAgent { get; set; }

        [JsonProperty("resolution")]
        public string? Resolution { get; set; }

        [JsonProperty("language")]
        public string? Language { get; set; }

        [JsonProperty("platform")]
        public string? Platform { get; set; }

        [JsonProperty("doNotTrack")]
        public bool? DoNotTrack { get; set; }

        [JsonProperty("hardwareConcurrency")]
        public int? HardwareConcurrency { get; set; }

        [JsonProperty("deviceMemory")]
        public int? DeviceMemory { get; set; }

        [JsonProperty("maxTouchPoints")]
        public int? MaxTouchPoints { get; set; }


        public override string ToString()
        {
            return $"Resolution: {Resolution}, Platform: {Platform}, DoNotTrack: {DoNotTrack}, " +
                $"HardwareConcurrency: {HardwareConcurrency}, DeviceMemory: {DeviceMemory}, MaxTouchPoints: {MaxTouchPoints}, UserAgent: {UserAgent}";
        }
    }
}
