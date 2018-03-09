using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FacialRecognitionApp.Abstractions;
using FacialRecognitionApp.Models;
using Newtonsoft.Json;
using SimpleClientService.Models;

namespace FacialRecognitionApp.Repositories
{
    public class FaceRepository : IFaceRepsoitory
    {
        private readonly IFaceService _faceClientService;

        public FaceRepository(IFaceService faceClientService)
        {
            _faceClientService = faceClientService;
        }

        public async Task<ApiResult> Post(string data)
        {
            var base64Array = Convert.FromBase64String(data);
            var arrayContent = new ByteArrayContent(base64Array);
            arrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            
            return await _faceClientService.DetectFace(arrayContent);
        }

        public async Task<bool> IdentifyUser(IdentifyApiModel data)
        {
            var detectFaceResponse = await Post(data.FaceData);

            if (!detectFaceResponse.IsSuccessStatusCode)
            {
                return false;
            }
            
            var faceModel = JsonConvert.DeserializeObject<IList<FaceModel>>(detectFaceResponse.ResponseBody).FirstOrDefault();

            string[] faceIds = { faceModel?.FaceId }; 

            var o = new
            {
                personGroupId = data.PersonGroupId,
                faceIds = faceIds,
                maxNumOfCandidatesReturned = data.MaxNumOfCandidatesReturned
            };
            
            var payload = new StringContent(JsonConvert.SerializeObject(o));
            payload.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var identifyResponse = await _faceClientService.Identify(payload);

            return identifyResponse.IsSuccessStatusCode;
        }
    }
}