using System.Threading;
using System.Threading.Tasks;
using TqkLibrary.Gologin.Api.DataClasses;
using TqkLibrary.Net;

namespace TqkLibrary.Gologin.Api
{
    public partial class GologinApi
    {
        internal partial class FingerprintApi
        {
            class GetNewImplement : BaseApiRequest<FingerprintGetNewRequest, FingerprintResponse>
            {
                readonly GologinApi _api;
                public GetNewImplement(GologinApi api)
                {
                    _api = api;
                }
                public override Task<string> RequestRawAsync(FingerprintGetNewRequest request, CancellationToken cancellationToken = default)
                {
                    return _api.Build()
                        .WithUrlGet(new UrlBuilder("https://api.gologin.com/browser/fingerprint")
                                .WithParam("os", request.Os)
                                .WithParamIfNotNull("resolution", request.Resolution))
                        .ExecuteAsync<string>(cancellationToken);

                }
            }
        }
    }
}
