using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TqkLibrary.Gologin.Api
{
    public class AudioContext
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("mode")]
        public AudioContextMode Mode { get; set; } = AudioContextMode.noise;

        [JsonProperty("noise")]
        public int Noise { get; set; } = Extensions.RandomNum;
    }

}
