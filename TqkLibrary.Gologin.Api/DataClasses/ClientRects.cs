using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TqkLibrary.Gologin.Api
{
    public class ClientRects
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("mode")]
        public ClientRectsMode Mode { get; set; } = ClientRectsMode.noise;

        [JsonProperty("noise")]
        public int Noise { get; set; } = Extensions.RandomNum;
    }

}
