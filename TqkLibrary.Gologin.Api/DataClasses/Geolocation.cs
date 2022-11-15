using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TqkLibrary.Gologin.Api
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Geolocation
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("mode")]
        public GeolocationMode Mode { get; set; } = GeolocationMode.prompt;

        [JsonProperty("enabled")]
        public bool Enabled { get; set; } = true;

        [JsonProperty("customize")]
        public bool Customize { get; set; } = true;

        [JsonProperty("fillBasedOnIp")]
        public bool FillBasedOnIp { get; set; } = true;

        [JsonProperty("latitude")]
        public double Latitude { get; set; } = 0;

        [JsonProperty("longitude")]
        public double Longitude { get; set; } = 0;

        [JsonProperty("accuracy")]
        public double Accuracy { get; set; } = 10;


        public override string ToString()
        {
            return $"Mode: {Mode}, Enabled: {Enabled}, Customize: {Customize}, FillBasedOnIp: {FillBasedOnIp}, LongLat: {Longitude},{Latitude}, Accuracy: {Accuracy}";
        }
    }

}
