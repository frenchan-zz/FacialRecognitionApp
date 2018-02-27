using SimpleClientService.Models;
using System.Threading.Tasks;

namespace FacialRecognitionApp.Repositories
{
    public interface IFaceRepsoitory
    {
        Task<ApiResult> Post(string data);
    }
}