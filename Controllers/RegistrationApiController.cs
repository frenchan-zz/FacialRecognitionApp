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

        public RegistrationApiController(IPersonGroupService personGroupService)
        {
            _personGroupService = personGroupService;
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
    }
}