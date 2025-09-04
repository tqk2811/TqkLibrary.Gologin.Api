using System;
using System.Threading;
using System.Threading.Tasks;

namespace TqkLibrary.Gologin.Api
{
    public partial class GologinApi
    {
        internal partial class ProfileApi
        {
            class GetAllImplement : BaseApiRequest<ProfileListResponse>
            {
                readonly GologinApi _api;
                internal GetAllImplement(GologinApi api)
                {
                    this._api = api ?? throw new ArgumentNullException(nameof(api));
                }
                public override Task<string> RequestRawAsync(CancellationToken cancellationToken = default)
                {
                    return _api.Build()
                        .WithUrlGet("https://api.gologin.com/browser/v2")
                        .ExecuteAsync<string>(cancellationToken);
                }
            }
        }
    }
}