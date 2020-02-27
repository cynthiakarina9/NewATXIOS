using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            browser.Source = "https://powerva.microsoft.com/webchat/bots/cef1fe29-4e84-40dc-92c6-9651a8afb4a9";
            this.Content = browser;
        }

    }
}