using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ATXBSAPP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new WebPage()));
        }

        async void FB_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.facebook.com/atxbusiness/");
        }

        async void LinkDnk_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.linkedin.com/company/atx-business-solutions/");
        }


    }
}