using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TqkLibrary.Gologin.Api.Exceptions;
using TqkLibrary.Gologin.Api.Interfaces;
using TqkLibrary.Net;

namespace TqkLibrary.Gologin.Api
{
    /// <summary>
    /// 
    /// </summary>
    public partial class GologinApi : BaseApi
    {
        readonly string _localEndPoint;
        /// <summary>
        /// 
        /// </summary>
        public GologinApi(string access_token, HttpMessageHandler httpMessageHandler, bool disposeHandle = true, string localEndPoint = "http://127.0.0.1:36912")
            : base(access_token, httpMessageHandler, disposeHandle)
        {
            if (string.IsNullOrWhiteSpace(access_token)) throw new ArgumentNullException(nameof(access_token));
            Uri uri = new Uri(localEndPoint);
            this._localEndPoint = $"{uri.Scheme}://{uri.Host}:{uri.Port}";

            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {access_token}");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "gologin-api");
            httpClient.DefaultRequestHeaders.Add("x-two-factor-token", "");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));

            this.Profile = new ProfileApi(this);
            this.Fingerprint = new FingerprintApi(this);
            this.Local = new LocalApi(this);
        }
        /// <summary>
        /// 
        /// </summary>
        public GologinApi(string access_token, string localEndPoint = "http://127.0.0.1:36912")
            : this(access_token, NetSingleton.HttpClientHandler, true, localEndPoint)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public IGologinProfileApi Profile { get; }

        /// <summary>
        /// 
        /// </summary>
        public IGologinFingerprintApi Fingerprint { get; }

        /// <summary>
        /// 
        /// </summary>
        public IGologinLocalApi Local { get; }









        protected override Task OnAfterRequestAsync(HttpResponseMessage httpResponseMessage)
        {
            return HandleError(httpResponseMessage);
        }




        IEnumerable<Error> ParseGologinErrorData(GologinErrorData gologinErrorData, params string[] propertyes)
        {
            if (!string.IsNullOrWhiteSpace(gologinErrorData.Property))
            {
                string[] _propertyes = propertyes.AsEnumerable().Concat(gologinErrorData.Property).ToArray();
                if (gologinErrorData.Constraints != null)
                {
                    yield return new Error()
                    {
                        Property = string.Join(".", _propertyes),
                        Messages = gologinErrorData.Constraints
                    };
                }
                if (gologinErrorData.Children != null)
                {
                    foreach (var child in gologinErrorData.Children)
                    {
                        foreach (var err in ParseGologinErrorData(child, _propertyes))
                        {
                            yield return err;
                        }
                    }
                }
            }
        }
        async Task HandleError(HttpResponseMessage httpResponseMessage)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    string data = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    GologinErrorResponse? gologinErrorResponse = JsonConvert.DeserializeObject<GologinErrorResponse>(data);

                    List<Error> errors = new List<Error>();
                    if (gologinErrorResponse?.Message != null)
                    {
                        foreach (var item in gologinErrorResponse.Message)
                        {
                            errors.AddRange(ParseGologinErrorData(item));
                        }
                    }

                    throw new GologinException(new GologinError()
                    {
                        StatusCode = gologinErrorResponse?.StatusCode,
                        Message = gologinErrorResponse?.Error,
                        Errors = errors,
                    });
                }
                else
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                }
            }
        }
    }
}