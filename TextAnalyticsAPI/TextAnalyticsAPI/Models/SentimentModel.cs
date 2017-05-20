using System.Collections.Generic;

namespace TextAnalyticsAPI.Models
{
    public class SentimentModel
    {
        public SentimentModel()
        {
            documents = new List<Document>();
            errors = new List<object>();
        }

        public List<Document> documents { get; set; }
        public List<object> errors { get; set; }

        public class Document
        {
            public double score { get; set; }
            public string id { get; set; }
        }
    }
}