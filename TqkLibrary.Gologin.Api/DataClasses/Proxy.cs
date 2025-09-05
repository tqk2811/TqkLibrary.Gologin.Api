using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TqkLibrary.Gologin.Api.Enums;

namespace TqkLibrary.Gologin.Api.DataClasses
{
    public class Proxy
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("mode")]
        public ProxyMode? Mode { get; set; } = ProxyMode.none;

        [JsonProperty("host")]
        public required string Host { get; set; }

        [JsonProperty("port")]
        public required int Port { get; set; } = 80;

        [JsonProperty("username")]
        public string? Username { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("connectionType")]
        public string? ConnectionType { get; set; }

        [JsonProperty("trafficLimit")]
        public int? TrafficLimit { get; set; }

        [JsonProperty("trafficUsed")]
        public string? TrafficUsed { get; set; }

        [JsonProperty("fakeProxyId")]
        public string? FakeProxyId { get; set; }

        [JsonProperty("autoProxyRegion")]
        public string? AutoProxyRegion { get; set; }

        [JsonProperty("torProxyRegion")]
        public string? TorProxyRegion { get; set; }

        [JsonProperty("customName")]
        public string? CustomName { get; set; }

        public override string ToString()
        {
            return $"Mode: {Mode}, Proxy: {Username}:{Password}@{Host}:{Port}";
        }
    }

}
