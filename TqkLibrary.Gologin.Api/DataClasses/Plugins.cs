using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api.DataClasses
{
    public class Plugins
    {
        [JsonProperty("enableVulnerable")]
        public bool EnableVulnerable { get; set; } = true;

        [JsonProperty("enableFlash")]
        public bool EnableFlash { get; set; } = false;

        public override string ToString()
        {
            return $"EnableVulnerable: {EnableVulnerable}, EnableFlash:{EnableFlash}";
        }
    }

}
