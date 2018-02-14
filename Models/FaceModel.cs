using System.Collections.Generic;
using Newtonsoft.Json;

namespace FacialRecognitionApp.Models
{
    public class FaceModel
    {
        [JsonProperty("faceId")]
        public string FaceId { get; set; }

        [JsonProperty("faceRectangle")]
        public FaceRectangle FaceRectangle { get; set; }

        [JsonProperty("faceAttributes")]
        public FaceAttributes FaceAttributes { get; set; }
    }

    public class FaceRectangle
    {
        [JsonProperty("top")]
        public double Top { get; set; }

        [JsonProperty("left")]
        public double Left { get; set; }

        [JsonProperty("widh")]
        public double Width { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }
    }

    public class HeadPose
    {
        [JsonProperty("pitch")]
        public double Pitch { get; set; }

        [JsonProperty("roll")]
        public double Roll { get; set; }

        [JsonProperty("yaw")]
        public double Yaw { get; set; }
    }

    public class FacialHair
    {
        [JsonProperty("moustache")]
        public double Moustache { get; set; }

        [JsonProperty("beard")]
        public double Beard { get; set; }

        [JsonProperty("sideburns")]
        public double Sideburns { get; set; }
    }

    public class Emotion
    {
        [JsonProperty("anger")]
        public double Anger { get; set; }

        [JsonProperty("contempt")]
        public double Contempt { get; set; }

        [JsonProperty("disgust")]
        public double Disgust { get; set; }

        [JsonProperty("fear")]
        public double Fear { get; set; }

        [JsonProperty("happiness")]
        public double Happiness { get; set; }

        [JsonProperty("neutral")]
        public double Neutral { get; set; }

        [JsonProperty("sadness")]
        public double Sadness { get; set; }

        [JsonProperty("surprise")]
        public double Surprise { get; set; }
    }

    public class Blur
    {
        [JsonProperty("blurLevel")]
        public string BlurLevel { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }

    public class Exposure
    {
        [JsonProperty("exposureLevel")]
        public string ExposureLevel { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }

    public class Noise
    {
        [JsonProperty("noiseLevel")]
        public string NoiseLevel { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }

    public class Makeup
    {
        [JsonProperty("eyeMakeup")]
        public bool EyeMakeup { get; set; }

        [JsonProperty("lipMakeup")]
        public bool LipMakeup { get; set; }
    }

    public class Occlusion
    {
        [JsonProperty("foreheadOccluded")]
        public bool ForeheadOccluded { get; set; }

        [JsonProperty("eyeOccluded")]
        public bool EyeOccluded { get; set; }

        [JsonProperty("mouthOccluded")]
        public bool MouthOccluded { get; set; }
    }

    public class HairColor
    {
        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }

    public class Hair
    {
        [JsonProperty("bald")]
        public double Bald { get; set; }

        [JsonProperty("invisible")]
        public bool Invisible { get; set; }

        [JsonProperty("hairColor")]
        public List<HairColor> HairColor { get; set; }
    }

    public class FaceAttributes
    {
        [JsonProperty("smile")]
        public double Smile { get; set; }

        [JsonProperty("headPose")]
        public HeadPose HeadPose { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("age")]
        public double Age { get; set; }

        [JsonProperty("facialHair")]
        public FacialHair FacialHair { get; set; }

        [JsonProperty("glasses")]
        public string Glasses { get; set; }

        [JsonProperty("emotion")]
        public Emotion Emotion { get; set; }

        [JsonProperty("blur")]
        public Blur Blur { get; set; }

        [JsonProperty("exposure")]
        public Exposure Exposure { get; set; }

        [JsonProperty("noise")]
        public Noise Noise { get; set; }

        [JsonProperty("makeup")]
        public Makeup Makeup { get; set; }

        [JsonProperty("accessories")]
        public List<object> Accessories { get; set; }

        [JsonProperty("occlusion")]
        public Occlusion Occlusion { get; set; }

        [JsonProperty("hair")]
        public Hair Hair { get; set; }
    }
}