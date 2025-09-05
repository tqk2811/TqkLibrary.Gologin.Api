using System.Collections.Generic;
using System.Linq;

namespace TqkLibrary.Gologin.Api.Exceptions
{
    public class Error
    {
        public string? Property { get; set; }
        public Dictionary<string, string>? Messages { get; set; }

        public override string ToString()
        {
            return $"Path: {Property}, Message: {string.Join(", ", Messages?.Select(x => x.Value) ?? Enumerable.Empty<string>())}";
        }
    }

}
