using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api.DataClasses
{
    public class Storage
    {
        [JsonProperty("local")]
        public bool Local { get; set; } = true;

        [JsonProperty("extensions")]
        public bool Extensions { get; set; } = true;

        [JsonProperty("bookmarks")]
        public bool Bookmarks { get; set; } = true;

        [JsonProperty("history")]
        public bool History { get; set; } = true;

        [JsonProperty("passwords")]
        public bool Passwords { get; set; } = true;

        [JsonProperty("session")]
        public bool Session { get; set; } = true;

        public override string ToString()
        {
            return $"Local: {Local}, Extensions:{Extensions}, Bookmarks: {Bookmarks}, History:{History}, Passwords:{Passwords}, Session:{Session}";
        }
    }

}
