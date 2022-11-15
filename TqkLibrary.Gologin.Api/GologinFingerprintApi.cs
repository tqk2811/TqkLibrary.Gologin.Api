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
    public interface IGologinFingerprintApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="os"></param>
        /// <param name="resolution"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<FingerprintResponse> GetNew(string os, string resolution, CancellationToken cancellationToken = default);
    }
    internal class GologinFingerprintApi : IGologinFingerprintApi
    {
        readonly GologinApi gologinApi;
        internal GologinFingerprintApi(GologinApi gologinApi)
        {
            this.gologinApi = gologinApi ?? throw new ArgumentNullException(nameof(gologinApi));
        }

        public async Task<FingerprintResponse> GetNew(string os, string resolution, CancellationToken cancellationToken = default)
        {
            NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(string.Empty);
            nameValueCollection["os"] = os;
            nameValueCollection["resolution"] = resolution;

            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                $"/browser/fingerprint?{nameValueCollection}");

            return await gologinApi.Request<FingerprintResponse>(httpRequestMessage, cancellationToken).ConfigureAwait(false);
        }
    }
}
