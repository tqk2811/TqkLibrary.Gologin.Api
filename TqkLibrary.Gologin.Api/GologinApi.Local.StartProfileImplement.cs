using System.Threading;
using System.Threading.Tasks;
using TqkLibrary.Net;

namespace TqkLibrary.Gologin.Api
{
    public partial class GologinApi
    {
        internal partial class LocalApi
        {
            class StartProfileImplement : BaseApiRequest<ProfileStartQuery, ProfileStatusResponse>
            {
                readonly GologinApi _api;
                internal StartProfileImplement(GologinApi api)
                {
                    this._api = api;
                }

                public override Task<string> RequestRawAsync(ProfileStartQuery request, CancellationToken cancellationToken = default)
                {
                    return _api.Build()
                        .WithUrlPostJson(new UrlBuilder(_api._localEndPoint, "browser/start-profile"), request)
                        .ExecuteAsync<string>(cancellationToken);
                }
            }
        }
    }
}