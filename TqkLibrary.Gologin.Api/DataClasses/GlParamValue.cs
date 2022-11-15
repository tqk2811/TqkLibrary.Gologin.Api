using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api
{
    public class GlParamValue
    {
        [JsonProperty("name")]
        public object Name { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }
}
