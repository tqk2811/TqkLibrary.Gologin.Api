using System;
using System.Threading;
using System.Threading.Tasks;
using TqkLibrary.Gologin.Api.DataClasses;
using TqkLibrary.Net;

namespace TqkLibrary.Gologin.Api
{
    public partial class GologinApi
    {
        internal partial class ProfileApi
        {
            class GetImplement : BaseApiRequest<ProfileQuery, ProfileResponse>
            {
                readonly GologinApi _api;
                internal GetImplement(GologinApi api)
                {
                    this._api = api ?? throw new ArgumentNullException(nameof(api));
                }

                public override Task<string> RequestRawAsync(ProfileQuery request, CancellationToken cancellationToken = default)
                {
                    return _api.Build()
                        .WithUrlGet(new UrlBuilder("https://api.gologin.com/browser", request.Id))
                        .ExecuteAsync<string>(cancellationToken);
                }
            }
        }
    }
}
