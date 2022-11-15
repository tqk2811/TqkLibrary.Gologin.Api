using Newtonsoft.Json;
using System.Collections.Generic;

namespace TqkLibrary.Gologin.Api
{
    public class Fonts
    {
        [JsonProperty("families")]
        public List<string> Families { get; set; }

        [JsonProperty("enableMasking")]
        public bool EnableMasking { get; set; }

        [JsonProperty("enableDomRect")]
        public bool EnableDomRect { get; set; }
    }

}
