using FacialRecognitionApp.Abstractions;
using Microsoft.Extensions.Configuration;
using SimpleClientService.Abstractions;
using SimpleClientService.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SimpleClientService.Extensions;

namespace FacialRecognitionApp.Services
{
    public class PersonGroupService : IPersonGroupService
    {
        private readonly IConfiguration _configuration;
        private readonly IClientService _clientService;

        public PersonGroupService(IConfiguration configuration, IClientService clientService)
        {
            _configuration = configuration;
            _clientService = clientService;
        }

        public async Task<ApiResult> Create(string personGroupId)
        {
            var uri = new Uri($"{ _configuration["ClientService:BaseApiUrl"] }face/v1.0/persongroups/{personGroupId}");
            var result = await _clientService.SimpleExecute(uri, HttpMethod.Put);

            return result;
        }

        public async Task<ApiResult> Delete(string personGroupId)
        {
            var uri = new Uri($"{ _configuration["ClientService:BaseApiUrl"] }face/v1.0/persongroups/{personGroupId}");
            var result = await _clientService.SimpleExecute(uri, HttpMethod.Delete);

            return result;
        }

        public async Task<ApiResult> Get(string personGroupId)
        {
            var uri = new Uri($"{ _configuration["ClientService:BaseApiUrl"] }face/v1.0/persongroups/{personGroupId}");
            var result = await _clientService.SimpleExecute(uri, HttpMethod.Get);

            return result;
        }

        public async Task<ApiResult> List(string start = null, string top = null)
        {
            var uri = new Uri($"{ _configuration["ClientService:BaseApiUrl"] }face/v1.0/persongroups")
                .AddParameter("start", start)
                .AddParameter("top", top);
            
            var result = await _clientService.SimpleExecute(uri, HttpMethod.Get);

            return result;
        }

        public async Task<ApiResult> Update(string personGroupId, StringContent payload)
        {
            payload.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            var uri = new Uri($"{ _configuration["ClientService:BaseApiUrl"] }face/v1.0/persongroups/{personGroupId}");
            var result = await _clientService.SimpleExecute(uri, new HttpMethod("PATCH"), payload);

            return result;
        }

        public async Task<ApiResult> Train(string personGroupId)
        {
            var uri = new Uri(
                $"{_configuration["ClientService:BaseApiUrl"]}face/v1.0/persongroups/{personGroupId}/train");
            var result = await _clientService.SimpleExecute(uri, HttpMethod.Post);

            return result;
        }
    }
}
