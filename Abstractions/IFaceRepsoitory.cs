using System.Threading.Tasks;
using FacialRecognitionApp.Models;
using SimpleClientService.Models;

namespace FacialRecognitionApp.Abstractions
{
    public interface IFaceRepsoitory
    {
        Task<ApiResult> Post(string data);
        Task<bool> IdentifyUser(IdentifyApiModel data);
    }
}