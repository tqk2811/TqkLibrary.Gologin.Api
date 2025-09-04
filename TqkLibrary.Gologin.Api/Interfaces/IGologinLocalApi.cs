using System.Threading;
using System.Threading.Tasks;

namespace TqkLibrary.Gologin.Api.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGologinLocalApi
    {
        BaseApiRequest<ProfileStartQuery, ProfileStatusResponse> StartProfile { get; }

        BaseApiRequest<ProfileQuery, ProfileStatusResponse> StopProfile { get; }
    }
}
