using System.Net.Http;
using System.Threading.Tasks;
using SimpleClientService.Models;

namespace FacialRecognitionApp.Abstractions
{
    public interface IFaceClientService
    {
        Task<ApiResult> DetectFace(ByteArrayContent byteArrayContent);
        Task<ApiResult> DetectFace(string imageFilePath);
    }
}