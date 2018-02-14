using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FacialRecognitionApp.Services
{
    public class FaceClientService : IFaceClientService
    {
        public static IConfiguration Configuration { get; set; }
        private const string UriBase = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0";

        public FaceClientService()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }


        public async Task<string> DetectFace(ByteArrayContent byteArrayContent)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Configuration.GetValue<string>("SubscriptionKey"));

            const string requestParameters = "returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";
            const string uri = UriBase + "/detect?" + requestParameters;

            using (var content = byteArrayContent)
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                var response = await client.PostAsync(uri, content);

                var contentString = await response.Content.ReadAsStringAsync();

                return contentString;
            }
        }

        public async Task<string> DetectFace(string imageFilePath)
        {
            var client = new HttpClient();

            // Request headers.
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Configuration.GetValue<string>("SubscriptionKey"));

            // Request parameters. A third optional parameter is "details".
            const string requestParameters = "returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";

            // Assemble the URI for the REST API Call.
            const string uri = UriBase + "/detect?" + requestParameters;

            // Request body. Posts a locally stored JPEG image.
            var byteData = GetImageAsByteArray(imageFilePath);

            using (var content = new ByteArrayContent(byteData))
            {
                // This example uses content type "application/octet-stream".
                // The other content types you can use are "application/json" and "multipart/form-data".
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                // Execute the REST API call.
                var response = await client.PostAsync(uri, content);

                // Get the JSON response.
                var contentString = await response.Content.ReadAsStringAsync();

                return contentString;
            }
        }

        private static byte[] GetImageAsByteArray(string imageFilePath)
        {
            var webClient = new WebClient();
            var imageBytes = webClient.DownloadData(imageFilePath);

            return imageBytes;
        }
    }
}