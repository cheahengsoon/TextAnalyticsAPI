using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextAnalyticsAPI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private void TextEditor_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextEditor.InvalidateLayout();
        }
    }
}