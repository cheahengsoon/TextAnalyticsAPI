using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TextAnalyticsAPI.Models.Body;

namespace TextAnalyticsAPI.Provider
{
    public class ServiceManager
    {
        private HttpResponseMessage response;
        private const string SubscriptionString = "{API_KEY_WILL_BE_HERE}";

        private const string SentimentUrl = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";
        private const string KeyPhrasesUrl = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/keyPhrases";
        private const string LanguagesUrl = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/languages?numberOfLanguagesToDetect=3";

        private async Task<HttpClient> GetClient()
        {
            var client = new HttpClient();
            return client;
        }

        public async Task<string> SentimentRequest(string data, string language)
        {
            try
            {
                var client = await GetClient();
                client.BaseAddress = new Uri(SentimentUrl);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionString);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                BodyModel body = new BodyModel();
                body.documents.Add(new BodyModel.Document()
                {
                    id = "1",
                    language = language,
                    text = data
                });

                byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(body));
                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(SentimentUrl, content);
                }

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async Task<string> KeyPhrasesRequest(string data, string language)
        {
            try
            {
                var client = await GetClient();
                client.BaseAddress = new Uri(KeyPhrasesUrl);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionString);

                BodyModel body = new BodyModel();
                body.documents.Add(new BodyModel.Document()
                {
                    id = "1",
                    language = language,
                    text = data
                });

                byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(body));
                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(KeyPhrasesUrl, content);
                }

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async Task<string> LanguageRequest(string data)
        {
            try
            {
                var client = await GetClient();
                client.BaseAddress = new Uri(LanguagesUrl);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionString);

                LanguageBodyModel body = new LanguageBodyModel();
                body.documents.Add(new LanguageBodyModel.Document()
                {
                    id = "1",
                    text = data
                });

                byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(body));
                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(LanguagesUrl, content);
                }

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}