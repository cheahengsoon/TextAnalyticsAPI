using System.Collections.Generic;

namespace TextAnalyticsAPI.Models.Body
{
    public class LanguageBodyModel
    {
        public LanguageBodyModel()
        {
            documents = new List<Document>();
        }

        public List<Document> documents { get; set; }

        public class Document
        {
            public string id { get; set; }
            public string text { get; set; }
        }
    }
}