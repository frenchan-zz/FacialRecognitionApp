using FacialRecognitionApp.Models;
using FacialRecognitionApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacialRecognitionApp.Controllers
{
    [Route("api/[controller]")]
    public class FaceApiController : Controller
    {
        private readonly IFaceRepsoitory _faceRepository;

        public FaceApiController(IFaceRepsoitory faceRepository)
        {
            _faceRepository = faceRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]FaceApiModel data)
        {
            if (data == null)
            {
                return new BadRequestObjectResult("Data is empty");
            }

            var response = await _faceRepository.Post(data.Data);

            return new OkObjectResult(JsonConvert.DeserializeObject<IList<FaceModel>>(response).FirstOrDefault());
        }
    }
}
