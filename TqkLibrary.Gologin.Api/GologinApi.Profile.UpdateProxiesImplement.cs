using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TqkLibrary.Net;

namespace TqkLibrary.Gologin.Api
{
    public partial class GologinApi
    {
        internal partial class ProfileApi
        {
            class UpdateProxiesImplement : BaseApiRequest<UpdateProxiesRequest, UpdateProxiesResponse>
            {
                readonly GologinApi _api;
                internal UpdateProxiesImplement(GologinApi api)
                {
                    this._api = api ?? throw new ArgumentNullException(nameof(api));
                }

                public override Task<string> RequestRawAsync(UpdateProxiesRequest request, CancellationToken cancellationToken = default)
                {
                    return _api.Build()
                        .WithUrl(new UrlBuilder("https://api.gologin.com/browser/proxy/many/v2"), new HttpMethod("Patch"))
                        .WithJsonBody(request)
                        .ExecuteAsync<string>(cancellationToken);
                }
            }
        }
    }
}
