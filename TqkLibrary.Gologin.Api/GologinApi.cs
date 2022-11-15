using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TqkLibrary.Gologin.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class GologinApi : IDisposable
    {
        readonly HttpClient httpClient;
        internal readonly int localPort = 36912;
        /// <summary>
        /// 
        /// </summary>
        public GologinApi(string access_token, HttpMessageHandler httpMessageHandler, bool disposeHandle = true, int localPort = 36912)
        {
            if (string.IsNullOrWhiteSpace(access_token)) throw new ArgumentNullException(nameof(access_token));
            this.localPort = localPort;

            httpClient = new HttpClient(httpMessageHandler, disposeHandle);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {access_token}");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "gologin-api");
            httpClient.DefaultRequestHeaders.Add("x-two-factor-token", "");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
            httpClient.BaseAddress = new Uri("https://api.gologin.com");

            this.Profile = new GologinProfileApi(this);
            this.Fingerprint = new GologinFingerprintApi(this);
            this.LocalApi = new GologinLocalApi(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        public GologinApi(string access_token, int localPort = 36912) : this(access_token, new HttpClientHandler(), true, localPort)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        ~GologinApi() => Dispose(false);

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        void Dispose(bool disposing)
        {
            httpClient.Dispose();
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
        public IGologinLocalApi LocalApi { get; }














        class GologinErrorResponse
        {
            [JsonProperty("statusCode")]
            public int StatusCode { get; set; }

            [JsonProperty("message")]
            public List<GologinErrorData> Message { get; set; }

            [JsonProperty("error")]
            public string Error { get; set; }
        }
        class GologinErrorData
        {
            [JsonProperty("property")]
            public string Property { get; set; }

            [JsonProperty("constraints")]
            public Dictionary<string, string> Constraints { get; set; }

            [JsonProperty("children")]
            public List<GologinErrorData> Children { get; set; }
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
                string data = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    GologinErrorResponse gologinErrorResponse = JsonConvert.DeserializeObject<GologinErrorResponse>(data);

                    List<Error> errors = new List<Error>();
                    if (gologinErrorResponse.Message != null)
                    {
                        foreach (var item in gologinErrorResponse.Message)
                        {
                            errors.AddRange(ParseGologinErrorData(item));
                        }
                    }

                    throw new GologinException(new GologinError()
                    {
                        StatusCode = gologinErrorResponse.StatusCode,
                        Message = gologinErrorResponse.Error,
                        Errors = errors,
                    });
                }
                else
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                }
            }
        }

        internal async Task Request(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken = default)
        {
            using HttpResponseMessage httpResponseMessage = await httpClient
                .SendAsync(httpRequestMessage, HttpCompletionOption.ResponseContentRead, cancellationToken)
                .ConfigureAwait(false);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                return;
            }
            else
            {
                await HandleError(httpResponseMessage).ConfigureAwait(false);
            }
        }
        internal async Task<T> Request<T>(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken = default)
        {
            using HttpResponseMessage httpResponseMessage = await httpClient
                .SendAsync(httpRequestMessage, HttpCompletionOption.ResponseContentRead, cancellationToken)
                .ConfigureAwait(false);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(data);
            }
            else
            {
                await HandleError(httpResponseMessage).ConfigureAwait(false);
                return default(T);
            }
        }

        internal async Task Request(HttpMethod httpMethod, string uri, CancellationToken cancellationToken = default)
        {
            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, uri);
            await Request(httpRequestMessage, cancellationToken).ConfigureAwait(false);
        }
        internal async Task<T> Request<T>(HttpMethod httpMethod, string uri, CancellationToken cancellationToken = default)
        {
            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, uri);
            return await Request<T>(httpRequestMessage, cancellationToken).ConfigureAwait(false);
        }


        static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        internal async Task<T> RequestPostJson<T>(string uri, object obj, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(uri)) throw new ArgumentNullException(nameof(uri));
            if (obj is null) throw new ArgumentNullException(nameof(obj));

            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
            string json = JsonConvert.SerializeObject(obj, jsonSerializerSettings);
            using StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            httpRequestMessage.Content = stringContent;
            return await Request<T>(httpRequestMessage, cancellationToken);
        }
        internal async Task RequestPostJson(string uri, object obj, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(uri)) throw new ArgumentNullException(nameof(uri));
            if (obj is null) throw new ArgumentNullException(nameof(obj));

            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
            string json = JsonConvert.SerializeObject(obj, jsonSerializerSettings);
            using StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            httpRequestMessage.Content = stringContent;
            await Request(httpRequestMessage, cancellationToken);
        }

    }
}