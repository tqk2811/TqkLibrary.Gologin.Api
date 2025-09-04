using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api
{
    public class ProfileStartQuery : ProfileQuery
    {
        [JsonProperty("sync")]
        public bool IsSync { get; set; } = true;
    }
}
