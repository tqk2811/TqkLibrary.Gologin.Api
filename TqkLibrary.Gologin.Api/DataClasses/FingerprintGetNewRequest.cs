using TqkLibrary.Gologin.Api.Interfaces;

namespace TqkLibrary.Gologin.Api
{
    public class FingerprintGetNewRequest : IDataRequest
    {
        public required string Os { get; set; }
        public string? Resolution { get; set; }

        public static implicit operator FingerprintGetNewRequest(string os) => new FingerprintGetNewRequest { Os = os };
    }

}
