using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api
{
    public class Timezone
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("fillBasedOnIp")]
        public bool FillBasedOnIp { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
    }

}
