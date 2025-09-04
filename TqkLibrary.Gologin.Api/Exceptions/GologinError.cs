using System.Collections.Generic;

namespace TqkLibrary.Gologin.Api.Exceptions
{
    public class GologinError
    {
        public int? StatusCode { get; set; }
        public IEnumerable<Error>? Errors { get; set; }
        public string? Message { get; set; }
    }

}
