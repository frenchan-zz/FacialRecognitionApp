using FacialRecognitionApp.Abstractions;
using Microsoft.Extensions.Configuration;
using SimpleClientService.Abstractions;
using SimpleClientService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
    }
}
