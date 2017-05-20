using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using TextAnalyticsAPI.Annotations;
using TextAnalyticsAPI.Models;
using TextAnalyticsAPI.Provider;
using Xamarin.Forms;

namespace TextAnalyticsAPI.ViewModels
{
    public class SentimentPageViewModel : INotifyPropertyChanged
    {
        private async void BindData()
        {
            var text = Application.Current.Properties["TextEditorData"] as string;
            var language = Application.Current.Properties["SelectedLanguage"] as string;
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(language))
                return;

            var manager = new ServiceManager();
            var data = await manager.SentimentRequest(text, language);
            var result = JsonConvert.DeserializeObject<SentimentModel>(data.ToString());
            if (result.documents.Count == 0)
                return;

            var score = result.documents[0].score;
            Progress = Convert.ToInt32(score * 100.0);

            if (this.Progress < 50)
                Status = "Sad";
            else if (this.Progress == 50)
                Status = "Normal";
            else if (this.Progress > 50)
                Status = "Happy";
        }

        public SentimentPageViewModel()
        {
            BindData();
        }

        private int _progress;
        private string _status;

        public int Progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
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