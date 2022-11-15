using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api
{
    public class MediaDevices
    {
        [JsonProperty("videoInputs")]
        public int? VideoInputs { get; set; }

        [JsonProperty("audioInputs")]
        public int? AudioInputs { get; set; }

        [JsonProperty("audioOutputs")]
        public int? AudioOutputs { get; set; }

        [JsonProperty("enableMasking")]
        public bool? EnableMasking { get; set; }

        public override string ToString()
        {
            return $"VideoInputs: {VideoInputs}, AudioInputs: {AudioInputs}, AudioOutputs: {AudioOutputs}, EnableMasking: {EnableMasking}";
        }
    }

}
