using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api.DataClasses
{
    public class ProfileStartQuery : ProfileQuery
    {
        [JsonProperty("sync")]
        public bool IsSync { get; set; } = true;
    }
}
