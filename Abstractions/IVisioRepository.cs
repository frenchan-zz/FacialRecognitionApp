using System.Threading.Tasks;
using SimpleClientService.Models;

namespace FacialRecognitionApp.Abstractions
{
    public interface IVisioRepository
    {
        Task<ApiResult> Post(string data);
    }
}