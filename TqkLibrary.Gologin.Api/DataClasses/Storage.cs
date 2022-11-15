using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api
{
    public class Storage
    {
        [JsonProperty("local")]
        public bool Local { get; set; }

        [JsonProperty("extensions")]
        public bool Extensions { get; set; }

        [JsonProperty("bookmarks")]
        public bool Bookmarks { get; set; }

        [JsonProperty("history")]
        public bool History { get; set; }

        [JsonProperty("passwords")]
        public bool Passwords { get; set; }

        [JsonProperty("session")]
        public bool Session { get; set; }
    }

}
