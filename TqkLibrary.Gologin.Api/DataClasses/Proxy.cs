using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api
{
    public class Proxy
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("port")]
        public int Port { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("connectionType")]
        public string ConnectionType { get; set; }

        [JsonProperty("trafficLimit")]
        public int TrafficLimit { get; set; }

        [JsonProperty("trafficUsed")]
        public string TrafficUsed { get; set; }

        [JsonProperty("fakeProxyId")]
        public string FakeProxyId { get; set; }

        [JsonProperty("autoProxyRegion")]
        public string AutoProxyRegion { get; set; }

        [JsonProperty("torProxyRegion")]
        public string TorProxyRegion { get; set; }
    }

}
