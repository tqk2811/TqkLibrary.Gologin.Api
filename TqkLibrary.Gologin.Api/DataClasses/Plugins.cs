using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api
{
    public class Plugins
    {
        [JsonProperty("enableVulnerable")]
        public bool EnableVulnerable { get; set; }

        [JsonProperty("enableFlash")]
        public bool EnableFlash { get; set; }
    }

}
