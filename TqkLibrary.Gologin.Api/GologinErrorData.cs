using Newtonsoft.Json;
using System.Collections.Generic;

namespace TqkLibrary.Gologin.Api
{
    class GologinErrorData
    {
        [JsonProperty("property")]
        public string Property { get; set; }

        [JsonProperty("constraints")]
        public Dictionary<string, string> Constraints { get; set; }

        [JsonProperty("children")]
        public List<GologinErrorData> Children { get; set; }
    }
}