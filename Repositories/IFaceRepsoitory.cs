using System.Threading.Tasks;

namespace FacialRecognitionApp.Repositories
{
    public interface IFaceRepsoitory
    {
        Task<string> Post(string data);
    }
}