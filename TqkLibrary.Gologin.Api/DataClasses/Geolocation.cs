using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TqkLibrary.Gologin.Api
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Geolocation
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("mode")]
        public GeolocationMode Mode { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("customize")]
        public bool Customize { get; set; }

        [JsonProperty("fillBasedOnIp")]
        public bool FillBasedOnIp { get; set; }

        [JsonProperty("latitude")]
        public int Latitude { get; set; }

        [JsonProperty("longitude")]
        public int Longitude { get; set; }

        [JsonProperty("accuracy")]
        public int Accuracy { get; set; }
    }

}
