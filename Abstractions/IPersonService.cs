using System.Net.Http;
using System.Threading.Tasks;
using SimpleClientService.Models;

namespace FacialRecognitionApp.Abstractions
{
    public interface IPersonService
    {
        Task<ApiResult> AddFace(string personGroupId, string personId, ByteArrayContent payload, string userData = null,
            string targetFace = null);
        Task<ApiResult> Create(string personGroupId, StringContent payload);
        Task<ApiResult> Delete(string personGroupId, string personId);
        Task<ApiResult> Get(string personGroupId, string personId);
        Task<ApiResult> List(string personGroupId, string start = null, string top = null);
        Task<ApiResult> Update(string personGroupId, string personId, StringContent payload);
        Task<ApiResult> Train(string personGroupId);
    }
}