using Newtonsoft.Json;
using System.Collections.Generic;
using TqkLibrary.Gologin.Api.Interfaces;

namespace TqkLibrary.Gologin.Api.DataClasses
{
    public class ProfileQuery : IDataRequest
    {
        [JsonProperty("profileId")]
        public required string Id { get; set; }


        public static implicit operator ProfileQuery(string id) => new() { Id = id };
    }
}
