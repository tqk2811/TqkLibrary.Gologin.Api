using System.Threading;
using System.Threading.Tasks;

namespace TqkLibrary.Gologin.Api.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGologinFingerprintApi
    {
        BaseApiRequest<FingerprintGetNewRequest, FingerprintResponse> GetNew { get; }
    }
}
