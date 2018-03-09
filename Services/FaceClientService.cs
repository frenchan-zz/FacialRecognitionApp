using Microsoft.Extensions.Configuration;
using SimpleClientService.Extensions;
using SimpleClientService.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SimpleClientService.Abstractions;
using FacialRecognitionApp.Abstractions;

namespace FacialRecognitionApp.Services
{
    public class FaceClientService : IFaceService
    {
        private readonly IConfiguration _configuration;
        private readonly IClientService _clientService;

        public FaceClientService(IConfiguration configuration, IClientService clientService)
        {
            _configuration = configuration;
            _clientService = clientService;
        }

        public async Task<ApiResult> DetectFace(ByteArrayContent byteArrayContent)
        {
            var uri = new Uri($"{_configuration["ClientService:BaseApiUrl"]}face/v1.0/detect")
                .AddParameter("returnFaceId", "true")
                .AddParameter("returnFaceLandmarks", "false")
                .AddParameter("returnFaceAttributes",
                    "age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise");

            var result = await _clientService.SimpleExecute(uri, HttpMethod.Post, byteArrayContent);

            return result;
        }

        public async Task<ApiResult> DetectFace(string imageFilePath)
        {
            var uri = new Uri($"{_configuration["ClientService:BaseApiUrl"]}face/v1.0/detect")
                .AddParameter("returnFaceId", "true")
                .AddParameter("returnFaceLandmarks", "false")
                .AddParameter("returnFaceAttributes",
                    "age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise");

            var byteData = GetImageAsByteArray(imageFilePath);
            var content = new ByteArrayContent(byteData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            var result = await _clientService.SimpleExecute(uri, HttpMethod.Post, content);

            return result;
        }
        
        private static byte[] GetImageAsByteArray(string imageFilePath)
        {
            var webClient = new WebClient();
            var imageBytes = webClient.DownloadData(imageFilePath);

            return imageBytes;
        }

        public async Task<ApiResult> Identify(StringContent payload)
        {
            var uri = new Uri($"{ _configuration["ClientService:BaseApiUrl"] }face/v1.0/identify");
            var result = await _clientService.SimpleExecute(uri, HttpMethod.Post, payload);

            return result;
        }

        public async Task<ApiResult> VerifyFace(StringContent payload)
        {
            payload.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var uri = new Uri($"{ _configuration["ClientService:BaseApiUrl"] }face/v1.0/verify");
            var result = await _clientService.SimpleExecute(uri, HttpMethod.Post, payload);

            return result;
        }
    }
}