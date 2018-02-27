using System.Net.Http;
using System.Threading.Tasks;

namespace FacialRecognitionApp.Services
{
    public interface IFaceClientService
    {
        Task<string> DetectFace(ByteArrayContent byteArrayContent);
        Task<string> DetectFace(string imageFilePath);
    }
}