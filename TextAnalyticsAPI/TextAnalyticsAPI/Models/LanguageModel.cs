using System.Collections.Generic;

namespace TextAnalyticsAPI.Models
{
    public class LanguageModel
    {
        public LanguageModel()
        {
            documents = new List<Document>();
            errors = new List<object>();
        }

        public List<Document> documents { get; set; }
        public List<object> errors { get; set; }

        public class DetectedLanguage
        {
            public string name { get; set; }
            public string iso6391Name { get; set; }
            public double score { get; set; }
        }

        public class Document
        {
            public string id { get; set; }
            public List<DetectedLanguage> detectedLanguages { get; set; }
        }
    }
}