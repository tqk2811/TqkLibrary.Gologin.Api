using Newtonsoft.Json;
using TqkLibrary.Gologin.Api.Interfaces;

namespace TqkLibrary.Gologin.Api.DataClasses
{
    public class ProfileStatusResponse : IDataResponse
    {
        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("wsUrl")]
        public string? WsUrl { get; set; }
    }

}
