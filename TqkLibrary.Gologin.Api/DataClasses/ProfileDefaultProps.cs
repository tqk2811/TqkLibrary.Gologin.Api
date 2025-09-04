using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api
{
    public class ProfileDefaultProps
    {
        [JsonProperty("profileNameIsDefault")]
        public bool? ProfileNameIsDefault { get; set; }

        [JsonProperty("profileNotesIsDefault")]
        public bool? ProfileNotesIsDefault { get; set; }
    }
}
