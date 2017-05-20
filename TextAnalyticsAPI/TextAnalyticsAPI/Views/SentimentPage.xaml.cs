using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextAnalyticsAPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SentimentPage : ContentPage
    {
        public SentimentPage()
        {
            InitializeComponent();
        }
    }
}