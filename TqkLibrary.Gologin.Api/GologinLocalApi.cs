using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TqkLibrary.Gologin.Api
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGologinLocalApi
    {
        Task StartProfile(string profileId, bool sync = true, CancellationToken cancellationToken = default);
        Task StopProfile(string profileId, CancellationToken cancellationToken = default);
    }

    internal class GologinLocalApi : IGologinLocalApi
    {
        readonly GologinApi gologinApi;
        internal GologinLocalApi(GologinApi gologinApi)
        {
            this.gologinApi = gologinApi;
        }

        public Task StartProfile(string profileId, bool sync = true, CancellationToken cancellationToken = default)
        {
            return gologinApi.RequestPostJson(
                $"http://localhost:{gologinApi.localPort}/browser/start-profile", 
                new { profileId = profileId, sync = sync }, 
                cancellationToken);

        }

        public Task StopProfile(string profileId, CancellationToken cancellationToken = default)
        {
            return gologinApi.RequestPostJson(
                $"http://localhost:{gologinApi.localPort}/browser/stop-profile",
                new { profileId = profileId },
                cancellationToken);
        }
    }
}
