using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using TextAnalyticsAPI.Models;
using TextAnalyticsAPI.Views;
using Xamarin.Forms;

namespace TextAnalyticsAPI.ViewModels
{
    public class MainPageViewModel
    {
        private void BindData()
        {
            List.Add(new MainPageModel
            {
                Title = "Sentiment",
                TargetType = typeof(SentimentPage)
            });
            List.Add(new MainPageModel
            {
                Title = "Languages",
                TargetType = typeof(LanguagesPage)
            });
            List.Add(new MainPageModel
            {
                Title = "KeyPhrases",
                TargetType = typeof(KeyPhrasesPage)
            });
        }

        public MainPageViewModel()
        {
            BindData();

            _textEditorCompletedCommand = new Command(onTextEditorCompleted);
            _itemSelectedCommand = new Command(onItemSelected);
        }

        private ICommand
            _textEditorCompletedCommand,
            _itemSelectedCommand;

        private List<MainPageModel> _list;

        public List<MainPageModel> List
        {
            get
            {
                if (_list == null)
                    _list = new List<MainPageModel>();
                return _list;
            }
            set { _list = value; }
        }

        public ICommand TextEditorCompletedCommand
        {
            get { return _textEditorCompletedCommand; }
            set
            {
                if (_textEditorCompletedCommand == null)
                    return;
                _textEditorCompletedCommand = value;
            }
        }

        public ICommand ItemSelectedCommand
        {
            get { return _itemSelectedCommand; }
            set
            {
                if (_itemSelectedCommand == null)
                    return;
                _itemSelectedCommand = value;
            }
        }


        private void onTextEditorCompleted(object e)
        {
            if (e != null)
                Application.Current.Properties["TextEditorData"] = e.ToString();
        }

        private async void onItemSelected(object e)
        {
            try
            {
                // Selected item control for options
                var item = e as MainPageModel;
                if (item == null)
                    return;

                // Input control for processes
                if (!Application.Current.Properties.ContainsKey("TextEditorData"))
                {
                    await Application.Current.MainPage.DisplayAlert("Warning", "You must write something!", "OK");
                    return;
                }

                // Language control
                if (item.TargetType == typeof(SentimentPage))
                {
                    var selectedLanguage = await Application.Current.MainPage
                        .DisplayActionSheet("Choose a language", "Cancel", "", "tr", "en");
                    if (string.IsNullOrEmpty(selectedLanguage))
                        Application.Current.Properties["SelectedLanguage"] = "en";
                    else
                        Application.Current.Properties["SelectedLanguage"] = selectedLanguage;

                    if (selectedLanguage == "Cancel")
                        return;
                }

                // Redirecting..
                await Application.Current.MainPage.Navigation.PushAsync(
                    (Page) Activator.CreateInstance(item.TargetType));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }
    }
}