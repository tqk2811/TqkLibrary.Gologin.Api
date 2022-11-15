using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TqkLibrary.Gologin.Api
{
    public class WebGLMetadata
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("mode")]
        public WebGLMetadataMode Mode { get; set; } = WebGLMetadataMode.mask;

        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        [JsonProperty("renderer")]
        public string Renderer { get; set; }
    }

}
