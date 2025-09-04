using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api
{
    public class ProfileProxyUpdate
    {
        [JsonProperty("id")]
        public required string Id { get; set; }

        [JsonProperty("proxy")]
        public required Proxy Proxy { get; set; }
    }
}
