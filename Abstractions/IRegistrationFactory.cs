using System.Threading.Tasks;
using FacialRecognitionApp.Models;

namespace FacialRecognitionApp.Abstractions
{
    public interface IRegistrationFactory
    {
        Task<bool> RegisterUser(RegisterApiModel data);
    }
}