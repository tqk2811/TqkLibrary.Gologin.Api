using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TqkLibrary.Gologin.Api
{
    public class Canvas
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("mode")]
        public CanvasMode Mode { get; set; } = CanvasMode.noise;

        [JsonProperty("noise")]
        public int Noise { get; set; } = Extensions.RandomNum;
    }

}
