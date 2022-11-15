using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api
{
    public class SupportedFunction
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("supported")]
        public bool Supported { get; set; }
    }

}
