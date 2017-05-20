using System.Collections.Generic;

namespace TextAnalyticsAPI.Models
{
    public class KeyPhrasesModel
    {
        public KeyPhrasesModel()
        {
            documents = new List<Document>();
            errors = new List<object>();
        }

        public List<Document> documents { get; set; }
        public List<object> errors { get; set; }

        public class Document
        {
            public List<string> keyPhrases { get; set; }
            public string id { get; set; }
        }
    }
}