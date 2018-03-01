using SimpleClientService.Models;
using System.Threading.Tasks;

namespace FacialRecognitionApp.Abstractions
{
    public interface IPersonGroupService
    {
        Task<ApiResult> Create(string personGroupId);
    }
}
