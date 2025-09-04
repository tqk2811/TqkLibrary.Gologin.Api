using Newtonsoft.Json;
using System.Collections.Generic;
using TqkLibrary.Gologin.Api.Interfaces;

namespace TqkLibrary.Gologin.Api
{
    public class ProfileListResponse : IDataResponse
    {
        [JsonProperty("profiles")]
        public List<ProfileResponse>? Profiles { get; set; }

        [JsonProperty("allProfilesCount")]
        public int? AllProfilesCount { get; set; }

        [JsonProperty("currentOrbitaMajorV")]
        public string? CurrentOrbitaMajorV { get; set; }

        [JsonProperty("currentBrowserV")]
        public string? CurrentBrowserV { get; set; }

        [JsonProperty("currentTestBrowserV")]
        public string? CurrentTestBrowserV { get; set; }

        [JsonProperty("currentTestOrbitaMajorV")]
        public string? CurrentTestOrbitaMajorV { get; set; }

        [JsonProperty("isFolderDeleted")]
        public bool? IsFolderDeleted { get; set; }
    }

}
