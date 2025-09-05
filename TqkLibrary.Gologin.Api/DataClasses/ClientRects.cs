using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TqkLibrary.Gologin.Api.Enums;

namespace TqkLibrary.Gologin.Api.DataClasses
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
