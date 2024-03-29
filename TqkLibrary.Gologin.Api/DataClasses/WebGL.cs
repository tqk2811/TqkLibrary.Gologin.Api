﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TqkLibrary.Gologin.Api
{
    public class WebGL
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("mode")]
        public WebGLMode? Mode { get; set; }

        [JsonProperty("getClientRectsNoise")]
        public int? GetClientRectsNoise { get; set; }

        [JsonProperty("noise")]
        public int? Noise { get; set; }

        public override string ToString()
        {
            return $"Mode: {Mode}, Noise: {Noise}, GetClientRectsNoise: {GetClientRectsNoise}";
        }
    }

}
