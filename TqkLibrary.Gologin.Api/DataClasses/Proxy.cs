using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TqkLibrary.Gologin.Api.Enums;

namespace TqkLibrary.Gologin.Api
{
    public class Proxy
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("mode")]
        public ProxyMode Mode { get; set; } = ProxyMode.none;

        [JsonProperty("host")]
        public string Host { get; set; } = string.Empty;

        [JsonProperty("port")]
        public int Port { get; set; } = 80;

        [JsonProperty("username")]
        public string Username { get; set; } = string.Empty;

        [JsonProperty("password")]
        public string Password { get; set; } = string.Empty;

        [JsonProperty("connectionType")]
        public string ConnectionType { get; set; }

        [JsonProperty("trafficLimit")]
        public int? TrafficLimit { get; set; }

        [JsonProperty("trafficUsed")]
        public string TrafficUsed { get; set; }

        [JsonProperty("fakeProxyId")]
        public string FakeProxyId { get; set; }

        [JsonProperty("autoProxyRegion")]
        public string AutoProxyRegion { get; set; } = "us";

        [JsonProperty("torProxyRegion")]
        public string TorProxyRegion { get; set; } = "us";

        public override string ToString()
        {
            return $"Mode: {Mode}, Proxy: {Username}:{Password}@{Host}:{Port}";
        }
    }

}
