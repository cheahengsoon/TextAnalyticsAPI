using System.Collections.Generic;

namespace TextAnalyticsAPI.Models.Body
{
    public class BodyModel
    {
        public BodyModel()
        {
            documents = new List<Document>();
        }

        public List<Document> documents { get; set; }

        public class Document
        {
            public string language { get; set; }
            public string id { get; set; }
            public string text { get; set; }
        }
    }
}