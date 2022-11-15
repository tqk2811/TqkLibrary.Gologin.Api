using Newtonsoft.Json;
using System.Collections.Generic;

namespace TqkLibrary.Gologin.Api
{


    public partial class ProfileConfig
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("browserType")]
        public string BrowserType { get; set; }

        [JsonProperty("os")]
        public string Os { get; set; }

        [JsonProperty("startUrl")]
        public string StartUrl { get; set; } = "https://iphey.com/";

        [JsonProperty("googleServicesEnabled")]
        public bool GoogleServicesEnabled { get; set; }

        [JsonProperty("lockEnabled")]
        public bool LockEnabled { get; set; }

        [JsonProperty("debugMode")]
        public bool DebugMode { get; set; }

        [JsonProperty("navigator")]
        public Navigator Navigator { get; set; }

        [JsonProperty("geoProxyInfo")]
        public GeoProxyInfo GeoProxyInfo { get; set; }

        [JsonProperty("storage")]
        public Storage Storage { get; set; }

        [JsonProperty("proxyEnabled")]
        public bool ProxyEnabled { get; set; }

        [JsonProperty("proxy")]
        public Proxy Proxy { get; set; }

        [JsonProperty("dns")]
        public string Dns { get; set; }

        [JsonProperty("plugins")]
        public Plugins Plugins { get; set; }

        [JsonProperty("timezone")]
        public Timezone Timezone { get; set; }

        [JsonProperty("audioContext")]
        public AudioContext AudioContext { get; set; } = new AudioContext();

        [JsonProperty("canvas")]
        public Canvas Canvas { get; set; } = new Canvas();

        [JsonProperty("fonts")]
        public Fonts Fonts { get; set; }

        [JsonProperty("mediaDevices")]
        public MediaDevices MediaDevices { get; set; }

        [JsonProperty("webRTC")]
        public WebRTC WebRTC { get; set; }

        [JsonProperty("webGL")]
        public WebGL WebGL { get; set; }

        [JsonProperty("clientRects")]
        public ClientRects ClientRects { get; set; } = new ClientRects();

        [JsonProperty("webGLMetadata")]
        public WebGLMetadata WebGLMetadata { get; set; }

        [JsonProperty("webglParams")]
        public WebglParams WebglParams { get; set; }

        [JsonProperty("profile")]
        public string Profile { get; set; }

        [JsonProperty("googleClientId")]
        public string GoogleClientId { get; set; }

        [JsonProperty("updateExtensions")]
        public bool UpdateExtensions { get; set; }

        [JsonProperty("chromeExtensions")]
        public List<string> ChromeExtensions { get; set; }

        [JsonProperty("geolocation")]
        public Geolocation Geolocation { get; set; }
    }

}
