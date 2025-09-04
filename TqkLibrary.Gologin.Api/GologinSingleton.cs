using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TqkLibrary.Gologin.Api
{
    internal static class GologinSingleton
    {
        public static JsonSerializerSettings JsonSerializerSettings { get; } = new()
        {
            NullValueHandling = NullValueHandling.Ignore,
#if DEBUG
            MissingMemberHandling = MissingMemberHandling.Error,
#endif
        };
    }
}
