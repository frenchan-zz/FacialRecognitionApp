using System.Net.Http;
using SimpleClientService.Models;
using System.Threading.Tasks;

namespace FacialRecognitionApp.Abstractions
{
    public interface IPersonGroupService
    {
        Task<ApiResult> Create(string personGroupId);
        Task<ApiResult> Delete(string personGroupId);
        Task<ApiResult> Get(string personGroupId);
        Task<ApiResult> List(string start = null, string top = null);
        Task<ApiResult> Update(string personGroupId, StringContent payload);
        Task<ApiResult> Train(string personGroupId);
    }
}
