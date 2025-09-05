using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api.DataClasses
{
    public class Tag
    {
        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; }

        [JsonProperty("field")]
        public string? Field { get; set; }

        [JsonProperty("_id")]
        public string? Id { get; set; }
    }
}
