using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TqkLibrary.Gologin.Api.Interfaces;

namespace TqkLibrary.Gologin.Api
{
    public abstract class BaseApiRequest
    {
        protected virtual void DebugWriteJson(string data, Type type)
        {
#if DEBUG
            string name = GetName(type);
            name = name.Replace(">", "〉").Replace("<", "〈");//〈 〉‹ ›《 》
            Path.GetInvalidFileNameChars().ToList().ForEach(c => name = name.Replace(c, '_'));
            Directory.CreateDirectory(".\\Responses");
            File.WriteAllText($".\\Responses\\{name}-{DateTime.Now:yyyy-MM-dd HH-mm-ss.ffffff}.g.json", data);
#endif
        }
        private string GetName(Type type)
        {
            if (type.IsGenericType)
            {
                string[] names = type.GenericTypeArguments.Select(x => GetName(x)).ToArray();
                return $"{type.Name.Replace("`1", string.Empty)}<{string.Join(", ", names)}>";
            }
            else
            {
                return type.Name;
            }
        }
    }
    public abstract class BaseApiRequest<TResponse> : BaseApiRequest
        where TResponse : class, IDataResponse
    {
        public virtual async Task<TResponse> RequestAsync(CancellationToken cancellationToken = default)
        {
            string data = await RequestRawAsync(cancellationToken);
            return JsonConvert.DeserializeObject<TResponse>(data, GologinSingleton.JsonSerializerSettings)!;
        }
        public abstract Task<string> RequestRawAsync(CancellationToken cancellationToken = default);
        protected virtual void DebugWriteJson(string data)
        {
            base.DebugWriteJson(data, typeof(TResponse));
        }
    }

    public abstract class BaseApiRequest<TRequest, TResponse> : BaseApiRequest
        where TRequest : class, IDataRequest
        where TResponse : class, IDataResponse
    {
        public virtual async Task<TResponse> RequestAsync(TRequest request, CancellationToken cancellationToken = default)
        {
            string data = await RequestRawAsync(request, cancellationToken);
            return JsonConvert.DeserializeObject<TResponse>(data, GologinSingleton.JsonSerializerSettings)!;
        }
        public abstract Task<string> RequestRawAsync(TRequest request, CancellationToken cancellationToken = default);
        protected virtual void DebugWriteJson(string data)
        {
            base.DebugWriteJson(data, typeof(TResponse));
        }
    }
}
