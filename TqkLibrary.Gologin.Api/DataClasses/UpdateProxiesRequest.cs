using Newtonsoft.Json;
using System.Collections.Generic;
using TqkLibrary.Gologin.Api.Interfaces;

namespace TqkLibrary.Gologin.Api.DataClasses
{
    public class UpdateProxiesRequest : IDataRequest
    {
        [JsonProperty("proxies")]
        public required List<ProfileProxyUpdate> Proxies { get; set; }
    }
}
