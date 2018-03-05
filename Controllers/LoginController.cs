using FacialRecognitionApp.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FacialRecognitionApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IFaceRepsoitory _faceRepsoitory;
        private readonly IPersonService _personService;

        public LoginController(IFaceRepsoitory faceRepsoitory, IPersonService personService)
        {
            _faceRepsoitory = faceRepsoitory;
            _personService = personService;
        }
        
        
    }
}