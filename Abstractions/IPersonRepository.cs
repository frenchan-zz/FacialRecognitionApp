using System.Threading.Tasks;
using FacialRecognitionApp.Models;
using SimpleClientService.Models;

namespace FacialRecognitionApp.Abstractions
{
    public interface IPersonRepository
    {
        Task<ApiResult> CreatePersonId(RegisterApiModel data);
        Task<ApiResult> AddFaceToPerson(RegisterApiModel data);
    }
}