using System.Net.Http;
using System.Threading.Tasks;
using SimpleClientService.Models;

namespace FacialRecognitionApp.Abstractions
{
    public interface IFaceService
    {
        Task<ApiResult> DetectFace(ByteArrayContent byteArrayContent);
        Task<ApiResult> DetectFace(string imageFilePath);
        Task<ApiResult> Identify(StringContent payload); 
        Task<ApiResult> VerifyFace(StringContent payload);
    }
}