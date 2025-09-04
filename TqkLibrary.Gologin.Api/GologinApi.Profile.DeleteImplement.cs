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
            class DeleteImplement : BaseApiRequest<ProfileQuery, ProfileDeleteResponse>
            {
                readonly GologinApi _api;
                internal DeleteImplement(GologinApi api)
                {
                    this._api = api ?? throw new ArgumentNullException(nameof(api));
                }

                public override Task<string> RequestRawAsync(ProfileQuery request, CancellationToken cancellationToken = default)
                {
                    return _api.Build()
                        .WithUrl(new UrlBuilder("https://api.gologin.com/browser", request.Id), HttpMethod.Delete)
                        .ExecuteAsync<string>(cancellationToken);
                }
            }
        }
    }
}
