using System.Threading;
using System.Threading.Tasks;
using TqkLibrary.Gologin.Api.Interfaces;
using TqkLibrary.Gologin.Api.DataClasses;
using TqkLibrary.Net;

namespace TqkLibrary.Gologin.Api
{
    public partial class GologinApi
    {
        internal partial class LocalApi : IGologinLocalApi
        {
            readonly GologinApi _api;
            internal LocalApi(GologinApi api)
            {
                this._api = api;
                this.StartProfile = new StartProfileImplement(api);
                this.StopProfile = new StopProfileImplement(api);
            }
            public BaseApiRequest<ProfileStartQuery, ProfileStatusResponse> StartProfile { get; }

            public BaseApiRequest<ProfileQuery, ProfileStatusResponse> StopProfile { get; }
        }
    }
}