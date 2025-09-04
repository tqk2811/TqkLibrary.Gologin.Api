using Newtonsoft.Json;
using System.Collections.Generic;

namespace TqkLibrary.Gologin.Api
{
    class GologinErrorResponse
    {
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("message")]
        public List<GologinErrorData>? Message { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }
    }
}