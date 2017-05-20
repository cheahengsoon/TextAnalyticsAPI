using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TextAnalyticsAPI.Annotations;
using TextAnalyticsAPI.Models;
using TextAnalyticsAPI.Provider;
using Xamarin.Forms;

namespace TextAnalyticsAPI.ViewModels
{
    public class KeyPhrasesPageViewModel : INotifyPropertyChanged
    {
        private async void BindData()
        {
            try
            {
                var text = Application.Current.Properties["TextEditorData"] as string;
                if (string.IsNullOrEmpty(text))
                    return;

                var manager = new ServiceManager();
                var data = await manager.KeyPhrasesRequest(text, "en");
                var result = JsonConvert.DeserializeObject<KeyPhrasesModel>(data.ToString());
                if (result.documents.Count == 0)
                    return;

                foreach (var item in result.documents)
                {
                    foreach (var key in item.keyPhrases)
                    {
                        KeyPhrases += key + ", ";
                    }
                }

                if (string.IsNullOrEmpty(KeyPhrases))
                    KeyPhrases = "NULL";
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        // Constructor
        public KeyPhrasesPageViewModel()
        {
            BindData();
        }

        private string _keyPhrases;

        public string KeyPhrases
        {
            get { return _keyPhrases; }
            set
            {
                _keyPhrases = value;
                OnPropertyChanged(nameof(KeyPhrases));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}