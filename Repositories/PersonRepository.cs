using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FacialRecognitionApp.Abstractions;
using FacialRecognitionApp.Models;
using Newtonsoft.Json;
using SimpleClientService.Models;

namespace FacialRecognitionApp.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IPersonService _personService;

        public PersonRepository(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<ApiResult> CreatePersonId(RegisterApiModel data)
        {
            var o = new
            {
                name = data.Name,
                userData = data.UserData
            };

            var payload = new StringContent(JsonConvert.SerializeObject(o));
            payload.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await _personService.Create(data.PersonGroupId, payload);
            await _personService.Train(data.PersonGroupId);

            return result;
        }

        public async Task<ApiResult> AddFaceToPerson(RegisterApiModel data)
        {
            var base64Array = Convert.FromBase64String(data.FaceData);
            var arrayContent = new ByteArrayContent(base64Array);
            arrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            var result = await _personService.AddFace(data.PersonGroupId, data.PersonId, arrayContent, data.UserData);

            return result;
        }
    }
}