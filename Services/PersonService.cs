using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FacialRecognitionApp.Abstractions;
using Microsoft.Extensions.Configuration;
using SimpleClientService.Abstractions;
using SimpleClientService.Extensions;
using SimpleClientService.Models;

namespace FacialRecognitionApp.Services
{
    public class PersonService : IPersonService
    {
        private readonly IConfiguration _configuration;
        private readonly IClientService _clientService;

        public PersonService(IConfiguration configuration, IClientService clientService)
        {
            _configuration = configuration;
            _clientService = clientService;
        }

        public async Task<ApiResult> AddFace(string personGroupId, string personId, string userData = null, string targetFace = null)
        {
            var uri = new Uri(
                    $"{_configuration["ClientService:BaseApiUrl"]}face/v1.0/persongroups/{personGroupId}/persons/{personId}/persistedFaces")
                .AddParameter("userData", userData)
                .AddParameter("targetFace", targetFace);
            
            var result = await _clientService.SimpleExecute(uri, HttpMethod.Post);

            return result;
        }

        public async Task<ApiResult> Create(string personGroupId, StringContent payload)
        {
            payload.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var uri = new Uri(
                $"{_configuration["ClientService:BaseApiUrl"]}face/v1.0/persongroups/{personGroupId}/persons");
            var result = await _clientService.SimpleExecute(uri, HttpMethod.Post, payload);

            return result;
        }

        public async Task<ApiResult> Delete(string personGroupId, string personId)
        {
            var uri = new Uri(
                $"{_configuration["ClientService:BaseApiUrl"]}face/v1.0/persongroups/{personGroupId}/persons/{personId}");
            var result = await _clientService.SimpleExecute(uri, HttpMethod.Delete);

            return result;
        }

        public async Task<ApiResult> Get(string personGroupId, string personId)
        {
            var uri = new Uri(
                $"{_configuration["ClientService:BaseApiUrl"]}face/v1.0/persongroups/{personGroupId}/persons/{personId}");
            var result = await _clientService.SimpleExecute(uri, HttpMethod.Get);

            return result;
        }

        public async Task<ApiResult> List(string personGroupId, string start = null, string top = null)
        {
            var uri = new Uri(
                $"{_configuration["ClientService:BaseApiUrl"]}face/v1.0/persongroups/{personGroupId}/persons")
                .AddParameter("start", start)
                .AddParameter("top", top);
            
            var result = await _clientService.SimpleExecute(uri, HttpMethod.Get);

            return result;
        }

        public async Task<ApiResult> Update(string personGroupId, string personId, StringContent payload)
        {
            payload.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var uri = new Uri(
                $"{_configuration["ClientService:BaseApiUrl"]}face/v1.0/persongroups/{personGroupId}/persons/{personId}");
            var result = await _clientService.SimpleExecute(uri, new HttpMethod("PATCH"), payload);

            return result;
        }
    }
}