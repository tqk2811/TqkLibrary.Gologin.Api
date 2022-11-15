using Newtonsoft.Json;
using System.Collections.Generic;

namespace TqkLibrary.Gologin.Api
{
    public class Extension
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; } = true;

        [JsonProperty("preloadCustom")]
        public bool PreloadCustom { get; set; } = true;

        [JsonProperty("names")]
        public List<string> Names { get; set; } = new List<string>();
    }

}
