using System.Threading.Tasks;
using FacialRecognitionApp.Abstractions;
using FacialRecognitionApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FacialRecognitionApp.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationApiController :  Controller
    {
        private readonly IPersonGroupService _personGroupService;
        private readonly IRegistrationFactory _registrationFactory;


        public RegistrationApiController(IPersonGroupService personGroupService, IRegistrationFactory registrationFactory)
        {
            _personGroupService = personGroupService;
            _registrationFactory = registrationFactory;
        }

        [HttpPost]
        [Route("createPerson")]
        public async Task<IActionResult> CreatePerson([FromBody] RegisterApiModel data)
        {
            if (data == null)
            {
                return new BadRequestObjectResult("Data is empty");
            }

            var successfullyRegistered = await _registrationFactory.RegisterUser(data);

            if (successfullyRegistered)
            {
                return new OkResult();
            }

            return new BadRequestObjectResult("Registration failed");
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromBody] string personGroupId)
        {
            if (string.IsNullOrEmpty(personGroupId)) {
                return new BadRequestObjectResult("Person Group Id is empty");
            }

            var response = await _personGroupService.Get(personGroupId);

            if (response.IsSuccessStatusCode)
            {
                return new OkObjectResult(response.ResponseBody);
            }

            return new BadRequestObjectResult(response.ResponseStatusCode);
        }

        [HttpPut]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] DataApiModel data)
        {
            if (data == null)
            {
                return new BadRequestObjectResult("Data is empty");
            }

            var response = await _personGroupService.Create(data.Data);

            if (response.IsSuccessStatusCode)
            {
                return new OkObjectResult(response.ResponseBody);
            }
            return new BadRequestObjectResult("Something went wrong");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DataApiModel data)
        {
            if (data == null)
            {
                return new BadRequestObjectResult("Data is empty");
            }

            var response = await _personGroupService.Delete(data.Data);

            if (response.IsSuccessStatusCode)
            {
                return new OkObjectResult(response.ResponseBody);
            }
            return new BadRequestObjectResult(response.ResponseStatusCode);
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            var response = await _personGroupService.List();

            if (response.IsSuccessStatusCode) {
                return new OkObjectResult(response.ResponseBody);
            }

            return new BadRequestObjectResult(response.ResponseStatusCode);
        }
    }
}