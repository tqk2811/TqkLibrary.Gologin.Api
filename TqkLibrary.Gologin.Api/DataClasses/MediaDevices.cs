using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api
{
    public class MediaDevices
    {
        [JsonProperty("videoInputs")]
        public int VideoInputs { get; set; } = 1;

        [JsonProperty("audioInputs")]
        public int AudioInputs { get; set; } = 1;

        [JsonProperty("audioOutputs")]
        public int AudioOutputs { get; set; } = 1;

        [JsonProperty("enableMasking")]
        public bool EnableMasking { get; set; }
    }

}
