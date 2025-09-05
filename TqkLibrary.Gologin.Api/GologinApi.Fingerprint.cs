using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TqkLibrary.Gologin.Api.Interfaces;
using TqkLibrary.Gologin.Api.DataClasses;
using TqkLibrary.Net;

namespace TqkLibrary.Gologin.Api
{
    public partial class GologinApi
    {
        internal partial class FingerprintApi : IGologinFingerprintApi
        {
            readonly GologinApi _api;
            public FingerprintApi(GologinApi gologinApi)
            {
                this._api = gologinApi ?? throw new ArgumentNullException(nameof(gologinApi));
                this.GetNew = new GetNewImplement(gologinApi);
            }

            public BaseApiRequest<FingerprintGetNewRequest, FingerprintResponse> GetNew { get; }
        }
    }
}
