using System.Threading;
using System.Threading.Tasks;
using TqkLibrary.Gologin.Api.DataClasses;
using TqkLibrary.Net;

namespace TqkLibrary.Gologin.Api
{
    public partial class GologinApi
    {
        internal partial class LocalApi
        {
            class StopProfileImplement : BaseApiRequest<ProfileQuery, ProfileStatusResponse>
            {
                readonly GologinApi _api;
                internal StopProfileImplement(GologinApi api)
                {
                    this._api = api;
                }

                public override Task<string> RequestRawAsync(ProfileQuery request, CancellationToken cancellationToken = default)
                {
                    return _api.Build()
                        .WithUrlPostJson(new UrlBuilder(_api._localEndPoint, "browser/stop-profile"), request)
                        .ExecuteAsync<string>(cancellationToken);
                }
            }
        }
    }
}