using Newtonsoft.Json;
using System.Collections.Generic;
using TqkLibrary.Gologin.Api.Interfaces;

namespace TqkLibrary.Gologin.Api
{
    public partial class ProfileConfig : IDataRequest
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("notes")]
        public string? Notes { get; set; }

        [JsonProperty("browserType")]
        public string? BrowserType { get; set; }

        [JsonProperty("devicePixelRatio")]
        public double? DevicePixelRatio { get; set; }

        [JsonProperty("isM1")]
        public bool IsM1 { get; set; } = false;

        [JsonProperty("os")]
        public string? Os { get; set; }

        [JsonProperty("startUrl")]
        public string? StartUrl { get; set; } = "https://iphey.com/";

        [JsonProperty("googleServicesEnabled")]
        public bool? GoogleServicesEnabled { get; set; }

        [JsonProperty("lockEnabled")]
        public bool LockEnabled { get; set; } = false;

        [JsonProperty("debugMode")]
        public bool DebugMode { get; set; } = false;

        [JsonProperty("navigator")]
        public Navigator? Navigator { get; set; }

        [JsonProperty("geoProxyInfo")]
        public GeoProxyInfo? GeoProxyInfo { get; set; }

        [JsonProperty("storage")]
        public Storage? Storage { get; set; }

        [JsonProperty("proxyEnabled")]
        public bool? ProxyEnabled { get; set; } = false;

        [JsonProperty("proxy")]
        public Proxy? Proxy { get; set; }

        [JsonProperty("dns")]
        public string? Dns { get; set; }

        [JsonProperty("plugins")]
        public Plugins? Plugins { get; set; }

        [JsonProperty("timezone")]
        public Timezone? Timezone { get; set; }

        [JsonProperty("audioContext")]
        public AudioContext? AudioContext { get; set; }

        [JsonProperty("canvas")]
        public Canvas? Canvas { get; set; }

        [JsonProperty("fonts")]
        public Fonts? Fonts { get; set; }

        [JsonProperty("mediaDevices")]
        public MediaDevices? MediaDevices { get; set; }

        [JsonProperty("webRTC")]
        public WebRTC? WebRTC { get; set; }

        [JsonProperty("webGL")]
        public WebGL? WebGL { get; set; }

        [JsonProperty("clientRects")]
        public ClientRects? ClientRects { get; set; }

        [JsonProperty("webGLMetadata")]
        public WebGLMetadata? WebGLMetadata { get; set; }

        [JsonProperty("webglParams")]
        public WebglParams? WebglParams { get; set; }

        [JsonProperty("googleClientId")]
        public string? GoogleClientId { get; set; }

        [JsonProperty("updateExtensions")]
        public bool? UpdateExtensions { get; set; }

        //[JsonProperty("chromeExtensions")]
        //public List<string> ChromeExtensions { get; set; }

        //[JsonProperty("chromeExtensionsToAllProfiles")]
        //public List<string> ChromeExtensionsToAllProfiles { get; set; }

        [JsonProperty("userChromeExtensions")]
        public List<string>? UserChromeExtensions { get; set; }

        [JsonProperty("userChromeExtensionsToNewProfiles")]
        public List<object>? UserChromeExtensionsToNewProfiles { get; set; }

        [JsonProperty("geolocation")]
        public Geolocation? Geolocation { get; set; }

        [JsonProperty("cookies")]
        public object[]? Cookies { get; set; }

        [JsonProperty("extensions")]
        public Extension? Extensions { get; set; }

        public override string ToString()
        {
            return $"{BrowserType}-{Os}: {Name}";
        }
    }

}
