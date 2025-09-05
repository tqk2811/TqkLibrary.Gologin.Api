using System.Threading;
using System.Threading.Tasks;
using TqkLibrary.Gologin.Api.DataClasses;

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
