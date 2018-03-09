namespace FacialRecognitionApp.Models
{
    public class IdentifyApiModel
    {
        public string PersonGroupId { get; set; }
        public int MaxNumOfCandidatesReturned  { get; set; }
        public double? ConfidenceThreshold  { get; set; }
        public string FaceData { get; set; }

        public IdentifyApiModel()
        {
            MaxNumOfCandidatesReturned = 10;
        }
    }
}