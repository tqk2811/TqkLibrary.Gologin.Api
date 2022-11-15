using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TqkLibrary.Gologin.Api
{
    public class WebGL
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("mode")]
        public WebGLMode Mode { get; set; } = WebGLMode.noise;

        [JsonProperty("getClientRectsNoise")]
        public int GetClientRectsNoise { get; set; }

        [JsonProperty("noise")]
        public int Noise { get; set; } = Extensions.RandomNum;
    }

}
