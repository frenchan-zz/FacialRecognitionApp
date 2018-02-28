using System;
using System.Net.Http;
using System.Threading.Tasks;
using FacialRecognitionApp.Abstractions;
using SimpleClientService.Models;

namespace FacialRecognitionApp.Repositories
{
    public class VisioRepository : IVisioRepository
    {
        private readonly IVisioService _visioService;

        public VisioRepository(IVisioService visioService)
        {
            _visioService = visioService;
        }
        
        public async Task<ApiResult> Post(string data)
        {
            var base64Array = Convert.FromBase64String(data);

            var arrayContent = new ByteArrayContent(base64Array);

            return await _visioService.Description(arrayContent);
        }
    }
}