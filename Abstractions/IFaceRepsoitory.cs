using System.Threading.Tasks;
using SimpleClientService.Models;

namespace FacialRecognitionApp.Abstractions
{
    public interface IFaceRepsoitory
    {
        Task<ApiResult> Post(string data);
    }
}