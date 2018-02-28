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
    public class VisioService : IVisioService
    {
        private readonly IConfiguration _configuration;
        private readonly IClientService _clientService;

        public VisioService(IConfiguration configuration, IClientService clientService) {
            _configuration = configuration;
            _clientService = clientService;
        }

        public async Task<ApiResult> Description(ByteArrayContent byteArrayContent)
        {
            var uri = new Uri($"{ _configuration["ClientService:BaseApiUrl"] }vision/v1.0/analyze")
                .AddParameter("visualFeatures", "Categories,Tags,Description,Adult")
                .AddParameter("details", "Celebrities,Landmarks");

            var httpClientHandler = new HttpClientHandler
            {
                AllowAutoRedirect = true
            };

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = uri
            };

            httpRequestMessage.Headers.Add("Cache-Control", "no-cache");
            httpRequestMessage.Headers.Add(_configuration["ClientService:CustomHeaderType"], _configuration["ClientService:VisioSubscriptionKey"]);

            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            var result = await _clientService.Execute(httpClientHandler, httpRequestMessage, byteArrayContent);

            return result;
        }
    }
}
