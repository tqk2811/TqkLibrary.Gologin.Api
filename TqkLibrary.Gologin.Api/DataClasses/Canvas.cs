using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TqkLibrary.Gologin.Api
{
    public class Canvas
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("mode")]
        public CanvasMode? Mode { get; set; }

        [JsonProperty("noise")]
        public int? Noise { get; set; }

        public override string ToString()
        {
            return $"Mode: {Mode}, Noise: {Noise}";
        }
    }

}
