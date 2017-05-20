using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
using TextAnalyticsAPI.Models;
using TextAnalyticsAPI.Provider;
using Xamarin.Forms;

namespace TextAnalyticsAPI.ViewModels
{
    public class LanguagesPageViewModel
    {
        private async void BindData()
        {
            try
            {
                var text = Application.Current.Properties["TextEditorData"] as string;
                if (string.IsNullOrEmpty(text))
                    return;

                var manager = new ServiceManager();
                var data = await manager.LanguageRequest(text);
                var result = JsonConvert.DeserializeObject<LanguageModel>(data.ToString());
                if (result.documents.Count == 0)
                    return;

                foreach (var item in result.documents)
                {
                    foreach (var language in item.detectedLanguages)
                    {
                        if (language == null)
                            continue;

                        List.Add(language);
                    }
                }
                if (List.Count == 0)
                    List.Add(new LanguageModel.DetectedLanguage()
                    {
                        name = "NULL",
                        iso6391Name = "unknown",
                        score = 0
                    });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        public LanguagesPageViewModel()
        {
            BindData();
        }

        private ObservableCollection<LanguageModel.DetectedLanguage> _list;

        public ObservableCollection<LanguageModel.DetectedLanguage> List
        {
            get
            {
                if (_list == null)
                    _list = new ObservableCollection<LanguageModel.DetectedLanguage>();
                return _list;
            }
            set { _list = value; }
        }
    }
}