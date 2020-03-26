using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebPage : ContentPage
    {
        public WebPage()
        {
            Title = "ChatBot";
            InitializeComponent();
            var browser = new WebView();
            browser.Source = "https://powerva.microsoft.com/webchat/bots/e3c8c8f5-3163-445b-926a-4f4b20826026";
            this.Content = browser;
        }
        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}