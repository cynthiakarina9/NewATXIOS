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
            InitializeComponent();
            var browser = new WebView();
            browser.Source = "https://webchat.botframework.com/embed/WebAppBotEx?s=Wg8eyyHzrnU.cwA.h-w.G6Vo4iJ1hSnBqZjZrzxN-a_FLqT_D2U0K_3224Mj044";
            this.Content = browser;
        }
    }
}