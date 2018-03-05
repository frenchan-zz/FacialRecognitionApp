namespace FacialRecognitionApp.Models
{
    public class RegisterApiModel
    {
        public string PersonGroupId { get; set; }
        public string PersonId { get; set; }
        public string Name { get; set; }
        public string UserData { get; set; }
        public string FaceData { get; set; }
    }
}