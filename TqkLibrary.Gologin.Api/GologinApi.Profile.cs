using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TqkLibrary.Gologin.Api.Interfaces;
using TqkLibrary.Gologin.Api.DataClasses;
using TqkLibrary.Net;

namespace TqkLibrary.Gologin.Api
{
    public partial class GologinApi
    {
        internal partial class ProfileApi : IGologinProfileApi
        {
            readonly GologinApi _api;
            internal ProfileApi(GologinApi api)
            {
                this._api = api ?? throw new ArgumentNullException(nameof(api));
                this.GetAll = new GetAllImplement(api);
                this.Create = new CreateImplement(api);
                this.Get = new GetImplement(api);
                this.Delete = new DeleteImplement(api);
                this.UpdateProxies = new UpdateProxiesImplement(api);
            }

            public BaseApiRequest<ProfileConfig, ProfileResponse> Create { get; }

            public BaseApiRequest<ProfileQuery, ProfileResponse> Get { get; }

            public BaseApiRequest<ProfileQuery, ProfileDeleteResponse> Delete { get; }

            public BaseApiRequest<ProfileListResponse> GetAll { get; }

            public BaseApiRequest<UpdateProxiesRequest, UpdateProxiesResponse> UpdateProxies { get; }
        }
    }
}
