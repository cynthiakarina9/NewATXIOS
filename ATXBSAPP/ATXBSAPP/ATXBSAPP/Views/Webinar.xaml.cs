using ATXAPP;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ATXBSAPP.ViewModels.NewsViewModel;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Webinar : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        RestServiceWebinar _restService;
        public Webinar()
        {
            InitializeComponent();
            Title = "Webinars";
            _restService = new RestServiceWebinar();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            string url = "http://atxcrmws.azurewebsites.net/adx_ads.asmx";
            List<ValueN> weatherData = await _restService.GetWeatherData3Async();
            BindingContext = weatherData;
            OnAppearing();
        }
        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new WebPage()));
        }
    }
}