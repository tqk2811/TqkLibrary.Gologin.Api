using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TqkLibrary.Gologin.Api.Enums;

namespace TqkLibrary.Gologin.Api.DataClasses
{
    public class AudioContext
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("mode")]
        public AudioContextMode? Mode { get; set; } = AudioContextMode.noise;

        [JsonProperty("noise")]
        public int? Noise { get; set; }

        public override string ToString()
        {
            return $"Mode: {Mode}, Noise: {Noise}";
        }
    }

}
