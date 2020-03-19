using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Webinar : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        public Webinar()
        {
            InitializeComponent();
            BindingContext = this;
            Title = "Webinars";
        }

        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new WebPage()));
        }
    }
}