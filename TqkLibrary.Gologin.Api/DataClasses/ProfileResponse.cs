using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TqkLibrary.Gologin.Api
{
    public class ProfileResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("browserType")]
        public string BrowserType { get; set; }

        [JsonProperty("lockEnabled")]
        public bool LockEnabled { get; set; }

        [JsonProperty("timezone")]
        public Timezone Timezone { get; set; }

        [JsonProperty("navigator")]
        public Navigator Navigator { get; set; }

        [JsonProperty("geolocation")]
        public Geolocation Geolocation { get; set; }

        [JsonProperty("debugMode")]
        public bool DebugMode { get; set; }

        [JsonProperty("os")]
        public string Os { get; set; }

        [JsonProperty("proxy")]
        public Proxy Proxy { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("chromeExtensions")]
        public List<string> ChromeExtensions { get; set; }
    }

}
