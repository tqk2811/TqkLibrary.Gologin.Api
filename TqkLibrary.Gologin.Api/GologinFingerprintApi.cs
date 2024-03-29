﻿using System;
using System.Collections.Specialized;
using System.Net.Http;
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
        Task<FingerprintResponse> GetNew(string os, string resolution = null, CancellationToken cancellationToken = default);
    }
    internal class GologinFingerprintApi : IGologinFingerprintApi
    {
        readonly GologinApi gologinApi;
        internal GologinFingerprintApi(GologinApi gologinApi)
        {
            this.gologinApi = gologinApi ?? throw new ArgumentNullException(nameof(gologinApi));
        }

        public async Task<FingerprintResponse> GetNew(string os, string resolution = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(os)) throw new ArgumentNullException(nameof(os));
            NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(string.Empty);
            nameValueCollection["os"] = os;
            if (!string.IsNullOrWhiteSpace(resolution)) nameValueCollection["resolution"] = resolution;

            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                $"/browser/fingerprint?{nameValueCollection}");

            return await gologinApi.Request<FingerprintResponse>(httpRequestMessage, cancellationToken).ConfigureAwait(false);
        }
    }
}
