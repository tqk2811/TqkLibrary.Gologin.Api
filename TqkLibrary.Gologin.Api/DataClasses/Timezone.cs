using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api
{
    public class Timezone
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; } = true;

        [JsonProperty("fillBasedOnIp")]
        public bool FillBasedOnIp { get; set; } = true;

        [JsonProperty("timezone")]
        public string TimeZone { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Enabled: {Enabled}, FillBasedOnIp: {FillBasedOnIp}, TimeZone: {TimeZone}";
        }
    }

}
