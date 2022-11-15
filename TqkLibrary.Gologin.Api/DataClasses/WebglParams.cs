using Newtonsoft.Json;
using System.Collections.Generic;

namespace TqkLibrary.Gologin.Api
{
    public class WebglParams
    {
        [JsonProperty("glCanvas")]
        public string GlCanvas { get; set; }

        [JsonProperty("supportedFunctions")]
        public List<SupportedFunction> SupportedFunctions { get; set; }

        [JsonProperty("glParamValues")]
        public List<GlParamValue> GlParamValues { get; set; }

        [JsonProperty("antialiasing")]
        public bool Antialiasing { get; set; }

        [JsonProperty("textureMaxAnisotropyExt")]
        public int TextureMaxAnisotropyExt { get; set; }

        [JsonProperty("shaiderPrecisionFormat")]
        public string ShaiderPrecisionFormat { get; set; }

        [JsonProperty("extensions")]
        public List<string> Extensions { get; set; }
    }

}
