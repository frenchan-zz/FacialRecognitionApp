using System.Net.Http;
using System.Threading.Tasks;
using SimpleClientService.Models;

namespace FacialRecognitionApp.Abstractions
{
    public interface IVisioService
    {
        Task<ApiResult> Description(ByteArrayContent byteArrayContent);
    }
}
