using Newtonsoft.Json;
using System.Collections.Generic;

namespace TqkLibrary.Gologin.Api
{
    public class FingerprintResponse
    {
        [JsonProperty("navigator")]
        public Navigator Navigator { get; set; }

        [JsonProperty("canvas")]
        public Canvas Canvas { get; set; }

        [JsonProperty("mediaDevices")]
        public MediaDevices MediaDevices { get; set; }

        [JsonProperty("webRTC")]
        public WebRTC WebRTC { get; set; }

        [JsonProperty("webGLMetadata")]
        public WebGLMetadata WebGLMetadata { get; set; }

        [JsonProperty("webglParams")]
        public WebglParams WebglParams { get; set; }

        [JsonProperty("webGL")]
        public WebGL WebGL { get; set; }

        [JsonProperty("clientRects")]
        public ClientRects ClientRects { get; set; }

        [JsonProperty("os")]
        public string Os { get; set; }

        [JsonProperty("devicePixelRatio")]
        public double? DevicePixelRatio { get; set; }

        [JsonProperty("fonts")]
        public List<string> Fonts { get; set; }

        [JsonProperty("extensionsToNewProfiles")]
        public List<object> ExtensionsToNewProfiles { get; set; }

        [JsonProperty("userExtensionsToNewProfiles")]
        public List<object> UserExtensionsToNewProfiles { get; set; }
    }

}
