using System.Collections.Generic;

namespace FacialRecognitionApp.Models
{
    public class VisioModel
    {
        public Description Description { get; set; }
        public string RequestId { get; set; }
        public Metadata Metadata { get; set; }
        public List<Tag> Tags { get; set; }
        public Adult Adult { get; set; }
    }

    public class Caption
    {
        public string Text { get; set; }
        public double Confidence { get; set; }
    }

    public class Description
    {
        public List<string> Tags { get; set; }
        public List<Caption> Captions { get; set; }
    }

    public class Metadata
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public string Format { get; set; }
    }

    public class Tag
    {
        public string Name { get; set; }
        public double Confidence { get; set; }
    }

    public class Adult
    {
        public bool IsAdultContent { get; set; }
        public double AdultScore { get; set; }
        public bool IsRacyContent { get; set; }
        public double RacyScore { get; set; }
    }
}
