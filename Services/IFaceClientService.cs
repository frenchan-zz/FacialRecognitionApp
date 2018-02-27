using SimpleClientService.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace FacialRecognitionApp.Services
{
    public interface IFaceClientService
    {
        Task<ApiResult> DetectFace(ByteArrayContent byteArrayContent);
        Task<ApiResult> DetectFace(string imageFilePath);
    }
}