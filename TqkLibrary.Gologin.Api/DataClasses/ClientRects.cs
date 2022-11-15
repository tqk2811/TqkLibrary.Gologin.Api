using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TqkLibrary.Gologin.Api
{
    public class ClientRects
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("mode")]
        public ClientRectsMode? Mode { get; set; }

        [JsonProperty("noise")]
        public int? Noise { get; set; }

        public override string ToString()
        {
            return $"Mode: {Mode}, Noise: {Noise}";
        }
    }

}
