using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api
{
    public class Navigator
    {
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

        [JsonProperty("resolution")]
        public string Resolution { get; set; } = "1600x900";

        [JsonProperty("language")]
        public string Language { get; set; } = "en-US,en;q=0.9";

        [JsonProperty("platform")]
        public string Platform { get; set; } = "Win32";

        [JsonProperty("doNotTrack")]
        public bool DoNotTrack { get; set; } = true;

        [JsonProperty("hardwareConcurrency")]
        public int HardwareConcurrency { get; set; } = Extensions.GetRandomNum(1, 64);

        [JsonProperty("deviceMemory")]
        public int DeviceMemory { get; set; } = Extensions.GetRandomParams(1, 2, 4, 6, 8);

        [JsonProperty("maxTouchPoints")]
        public int MaxTouchPoints { get; set; } = Extensions.GetRandomNum(1, 2);
    }
}
