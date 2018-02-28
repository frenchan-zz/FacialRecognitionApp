using FacialRecognitionApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacialRecognitionApp.Abstractions;

namespace FacialRecognitionApp.Controllers
{
    [Route("api/[controller]")]
    public class FaceApiController : Controller
    {
        private readonly IFaceRepsoitory _faceRepository;
        private readonly IVisioRepository _visioRepository;

        public FaceApiController(IFaceRepsoitory faceRepository, IVisioRepository visioRepository)
        {
            _faceRepository = faceRepository;
            _visioRepository = visioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]DataApiModel data)
        {
            if (data == null)
            {
                return new BadRequestObjectResult("Data is empty");
            }

            var response = await _faceRepository.Post(data.Data);
            var visioResponse = await _visioRepository.Post(data.Data);

            var visioModel = new VisioModel();

            if (visioResponse.IsSuccessStatusCode) {
                visioModel = JsonConvert.DeserializeObject<VisioModel>(visioResponse.ResponseBody);
            }

            var faceModel = new FaceModel();

            if(response.IsSuccessStatusCode)
            {
                faceModel = JsonConvert.DeserializeObject<IList<FaceModel>>(response.ResponseBody).FirstOrDefault();
            }

            var o = new
            {
                Id = faceModel?.FaceId,
                Description = visioModel.Description.Captions.FirstOrDefault()?.Text,
                FaceAttributes = faceModel?.FaceAttributes,
                Tags = visioModel.Tags
            };

            return new OkObjectResult(o);
        }
    }
}
