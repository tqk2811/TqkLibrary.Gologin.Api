using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api.DataClasses
{
    public class ProfileProxyUpdate
    {
        [JsonProperty("profileId")]
        public required string ProfileId { get; set; }

        [JsonProperty("proxy")]
        public required Proxy Proxy { get; set; }
    }
}
