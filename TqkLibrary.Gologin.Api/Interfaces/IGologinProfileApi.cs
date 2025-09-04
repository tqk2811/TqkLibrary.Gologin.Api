using System.Threading;
using System.Threading.Tasks;

namespace TqkLibrary.Gologin.Api.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGologinProfileApi
    {
        BaseApiRequest<ProfileConfig, ProfileResponse> Create { get; }

        BaseApiRequest<ProfileQuery, ProfileResponse> Get { get; }

        BaseApiRequest<ProfileQuery, ProfileDeleteResponse> Delete { get; }
    }
}
