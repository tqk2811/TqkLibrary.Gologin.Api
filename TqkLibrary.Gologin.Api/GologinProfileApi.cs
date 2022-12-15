using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace TqkLibrary.Gologin.Api
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGologinProfileApi
    {
        Task<ProfileResponse> Create(ProfileConfig profileConfig, CancellationToken cancellationToken = default);
        Task<ProfileResponse> Get(string id, CancellationToken cancellationToken = default);
        Task Delete(string profileId, CancellationToken cancellationToken = default);
    }
    internal class GologinProfileApi : IGologinProfileApi
    {
        readonly GologinApi gologinApi;
        internal GologinProfileApi(GologinApi gologinApi)
        {
            this.gologinApi = gologinApi ?? throw new ArgumentNullException(nameof(gologinApi));
        }

        public Task<ProfileResponse> Create(ProfileConfig profileConfig, CancellationToken cancellationToken = default)
        {
            return gologinApi.RequestPostJson<ProfileResponse>("/browser", profileConfig, cancellationToken);
        }
        public Task<ProfileResponse> Get(string id, CancellationToken cancellationToken = default)
        {
            return gologinApi.Request<ProfileResponse>(HttpMethod.Get, $"/browser/{id}", cancellationToken);
        }
        public Task Delete(string profileId, CancellationToken cancellationToken = default)
        {
            return gologinApi.Request(HttpMethod.Delete, $"/browser/{profileId}", cancellationToken);
        }
    }

}
