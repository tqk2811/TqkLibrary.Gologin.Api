using System;
using System.Threading;
using System.Threading.Tasks;

namespace TqkLibrary.Gologin.Api
{
    public partial class GologinApi
    {
        internal partial class ProfileApi
        {
            class CreateImplement : BaseApiRequest<ProfileConfig, ProfileResponse>
            {
                readonly GologinApi _api;
                internal CreateImplement(GologinApi api)
                {
                    this._api = api ?? throw new ArgumentNullException(nameof(api));
                }

                public override Task<string> RequestRawAsync(ProfileConfig request, CancellationToken cancellationToken = default)
                {
                    return _api.Build()
                        .WithUrlPostJson("https://api.gologin.com/browser", request)
                        .ExecuteAsync<string>(cancellationToken);
                }
            }
        }
    }
}
