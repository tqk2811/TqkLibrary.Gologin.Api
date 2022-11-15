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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="profileConfig"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ProfileResponse> Create(ProfileConfig profileConfig, CancellationToken cancellationToken = default);

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
            return gologinApi.RequestPost<ProfileResponse>("browser", profileConfig, cancellationToken);
        }

       
    }

}
